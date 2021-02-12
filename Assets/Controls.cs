using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private Rigidbody2D controller;
    public float MoveSpeed;
    public BoxCollider2D Hitbox;
    public BoxCollider2D Hurtbox;


    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 v = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        controller.transform.Translate(v.normalized * MoveSpeed);

    }
}
