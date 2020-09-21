using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GrabCollision : MonoBehaviour
{
    public GameObject heldObject;
    public bool tryingToGrab;
    private ConfigurableJoint objectJoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            tryingToGrab = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            tryingToGrab = false;
            if(heldObject != null)
            {
                heldObject = null;
                Destroy(objectJoint);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(tryingToGrab && heldObject == null)
        {
            heldObject = collision.gameObject;
            Vector3 colPoint = new Vector3(0, 0, 0);
            int colCount = 0;
            foreach (ContactPoint contact in collision.contacts)
            {
                colCount++;
                colPoint = contact.point;
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
            if (colCount > 1)
            {
                Debug.Log("Multiple Contact Points");
            }
            CreateJoint(colPoint);
        }
    }

    void CreateJoint(Vector3 colPosition)
    {
        objectJoint = this.gameObject.AddComponent<ConfigurableJoint>();
        objectJoint.angularXMotion = ConfigurableJointMotion.Locked;
        objectJoint.angularYMotion = ConfigurableJointMotion.Locked;
        objectJoint.angularZMotion = ConfigurableJointMotion.Locked;
        objectJoint.xMotion = ConfigurableJointMotion.Locked;
        objectJoint.yMotion = ConfigurableJointMotion.Locked;
        objectJoint.zMotion = ConfigurableJointMotion.Locked;
        objectJoint.connectedBody = heldObject.GetComponent<Rigidbody>();
    }
}
