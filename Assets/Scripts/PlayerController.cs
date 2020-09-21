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
    public float rotationAmount = 0;
    
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
        Vector3 forwardVector = new Vector3(0, 0, 1);
        Vector3 rightVector = new Vector3(1, 0, 0);

        Vector3 rotatedForwardVector = Quaternion.AngleAxis(playerTransform.eulerAngles.y, Vector3.up) * forwardVector;
        Vector3 rotatedRightVector = Quaternion.AngleAxis(playerTransform.eulerAngles.y, Vector3.up) * rightVector;

        Vector3 Horiz = verticalInput * rotatedForwardVector;
        Vector3 Vert = horizontalInput * rotatedRightVector;
        rigb.AddForce((Horiz + Vert) * moveSpeed);
        //rotate character
        rotationAmount += -lookHorizontalInput * rotateSpeed;
        Debug.Log("horiz: " + lookHorizontalInput);
        playerTransform.gameObject.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0, rotationAmount, 0);


        if (Input.GetButtonDown("Jump") && grounded) {
            Debug.Log("jump");
            jump();
        }
    }


    private void jump() {
        rigb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
