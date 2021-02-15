using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject p = GameObject.Find("Player");
        Vector3 v = (p.transform.position - this.transform.position).normalized;
        this.transform.position += MoveSpeed * v;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("collided with " +other.gameObject);
        if (other.gameObject.CompareTag("Spike"))
        {
            print("turning off");
            this.gameObject.SetActive(false);

        }
    }

}
