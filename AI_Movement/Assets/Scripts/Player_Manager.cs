using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 200;
    public float sprintSpeed = 150;
    public float rotationSpeed = 100;
    public float jumpForce = 175;
    private float vertical;
    private float horizontal;
    private bool isGrounded;
   
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        vertical = Input.GetAxis("Vertical"); 
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetAxis("Jump") > 0) {
            if(isGrounded) {
                rb.AddForce(transform.up * jumpForce);
            }
        }

        Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.D)) { // This one is fucked, fix it.
            Vector3 velocityRightLeft = (transform.right * horizontal) * speed * Time.fixedDeltaTime;
            velocityRightLeft.y = rb.velocity.x;
            rb.velocity = velocityRightLeft;
        }
    
        if(Input.GetKey(KeyCode.LeftShift)) {
            Vector3 sprintVelocity = (transform.forward * vertical) * speed * sprintSpeed * Time.fixedDeltaTime;
            sprintVelocity.y = rb.velocity.y;
            rb.velocity = sprintVelocity;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == ("Ground")) {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision) {
        if(collision.gameObject.tag == ("Ground")) {
            isGrounded = false;
        }
    }
}
