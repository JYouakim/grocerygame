using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay(Collision collision) {
        if (!collision.gameObject.CompareTag("Player")) {
            playerScript.grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (!collision.gameObject.CompareTag("Player")) {
            playerScript.grounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
