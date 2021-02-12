using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed;
    public float turnSpeed;
    public BoxCollider2D Hitbox;
    public BoxCollider2D Hurtbox;


    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //loosely modeled off of https://answers.unity.com/questions/122786/simple-tank-controller.html
        Quaternion rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * turnSpeed);
        transform.rotation *= rotation;
        
        Vector3 movDir = rotation * (transform.up * -Input.GetAxis("Vertical") * moveSpeed);
        controller.Move(movDir);

    }
}
