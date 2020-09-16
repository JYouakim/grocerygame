using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float rotateCorrectionSpeed = 200.0f;
    float moveSpeed = 20f;
    float jumpForce = 20f;
    float horizontalInput;
    float verticalInput;
    bool grounded;
    Rigidbody rigb;
    
    // Start is called before the first frame update
    void Start()
    {
        rigb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision) {
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // polling input
      
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rigb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed);
        // transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")) {
            jump();
        }

    }

    private void jump() {
        rigb.AddForce(new Vector3(0, jumpForce, 0));
        grounded = false;
    }
}
