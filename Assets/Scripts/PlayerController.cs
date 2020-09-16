using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float rotateCorrectionSpeed = 200.0f;
    float moveSpeed = 1;
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
        /**
        if (horizontalInput + verticalInput == 0.0f) {
            Debug.Log("rotation");
            var step = rotateCorrectionSpeed * Time.deltaTime;
            Quaternion rotateToward
            transform.rotation = Quaternion.RotateTowards(transform.rotation, , step);
        }
        */
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rigb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed);
        // transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);

    }
}
