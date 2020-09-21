using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 100f;
    public float rotateSpeed = 1f;
    public float jumpForce = 400f;
    public bool grounded = true;

    float horizontalInput;
    float verticalInput;
    float lookHorizontalInput;
    float lookVerticalInput;
    
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
        lookHorizontalInput = Input.GetAxis("LookHorizontal");
        lookVerticalInput = Input.GetAxis("LookVertical");

        Vector3 Horiz = horizontalInput * playerTransform.forward;
        Vector3 Vert = verticalInput * playerTransform.right;
        rigb.AddForce((Horiz + Vert) * moveSpeed);
        //rotate character
        Debug.Log("horiz: " + lookHorizontalInput);
        playerTransform.Rotate(new Vector3(0, lookHorizontalInput * rotateSpeed, 0));


        if (Input.GetButtonDown("Jump") && grounded) {
            Debug.Log("jump");
            jump();
        }
    }


    private void jump() {
        rigb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
