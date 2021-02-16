using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float MoveSpeed;
    public bool ignoreTrigger;
    public Collider2D triggerBox;
    public GameObject Stamp;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = (player.transform.position - this.transform.position).normalized;
        this.transform.position += MoveSpeed * v;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("collided with " + other.gameObject);
        if (other.gameObject.CompareTag("Spike") && !ignoreTrigger)
        {


            print("turning off");
            this.gameObject.SetActive(false);

            if (this.CompareTag("Boss"))
            {
                Stamp.SetActive(true);
                Camera c = FindObjectOfType<Camera>();
                c.GetComponent<FollowCam>().player = player;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    void removeTrigger()
    {
        this.triggerBox.enabled = false;
        ignoreTrigger = false;
    }

    void setSpeed(float speed)
    {
        this.MoveSpeed = speed;
    }

}
