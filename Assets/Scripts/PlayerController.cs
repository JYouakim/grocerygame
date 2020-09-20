using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float jumpForce = 400f;
    public bool grounded = true;

    float horizontalInput;
    float verticalInput;
    
    Rigidbody rigb;
    
    // Start is called before the first frame update
    void Start()
    {
        rigb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // polling input
      
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rigb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed);

        if (Input.GetButtonDown("Jump") && grounded) {
            Debug.Log("jump");
            jump();
        }
    }


    private void jump() {
        rigb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
