using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 2;
    public float sprintSpeed = 6;
    public float rotationSpeed = 1;
    public float jumpForce = 1;
    private float vertical;
    private float horizontal;
    private bool isGrounded;
   
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        vertical = Input.GetAxisRaw("Vertical"); 
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horizontal, rb.velocity.y, vertical) * speed * Time.fixedDeltaTime;

        if(Input.GetKey(KeyCode.LeftShift)) {
            rb.velocity = new Vector3(horizontal, rb.velocity.y, vertical) * speed * sprintSpeed * Time.fixedDeltaTime;
        }

        if(Input.GetAxis("Jump") > 0) {
            if(isGrounded) {
                rb.AddForce(transform.up * jumpForce, ForceMode.Acceleration);
            }
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
