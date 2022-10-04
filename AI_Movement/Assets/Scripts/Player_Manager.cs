using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 150f;
    public float sprintSpeed = 2f;
    public float jumpForce = 175f;
    private float vertical;
    private float horizontal;
    private bool isGrounded;
   
    void Start() {
        rb = GetComponent<Rigidbody>();
    }  

    void FixedUpdate() {
        vertical = Input.GetAxisRaw("Vertical"); //Gets vertical input
        horizontal = Input.GetAxisRaw("Horizontal"); //Gets horizontal input

        //rb.velocity cant be used as a variable, because of course it cant. so lets turn it into one so we can use it as such.
        Vector3 v = rb.velocity; 
        v.x = horizontal * speed * Time.fixedDeltaTime;
        v.z = vertical * speed * Time.fixedDeltaTime;
        rb.velocity = v;

        if(Input.GetKey(KeyCode.LeftShift)) { //Sprinting 
            rb.velocity = v * speed * sprintSpeed/3 * Time.fixedDeltaTime;
        }

        if(Input.GetAxis("Jump") > 0) { //Jumping
            if(isGrounded) {
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision) { //Are we grounded?
        if(collision.gameObject.tag == ("Ground")) {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision) { //Are we grounded?
        if(collision.gameObject.tag == ("Ground")) {
            isGrounded = false;
        }
    }
}
