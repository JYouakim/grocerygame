using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBone : MonoBehaviour
{
    public Transform playerTransform;
    ConfigurableJoint joint;
    Transform originalTrans;
    // Start is called before the first frame update
    void Start()
    {
        joint = gameObject.GetComponent<ConfigurableJoint>();
        originalTrans = gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetTargetRotation(joint, playerTransform.rotation, originalTrans.rotation);
    }

    /// <summary>
    /// Sets the target rotation of the joint to be the given rotation relative to the original rotation
    /// </summary>
    /// <param name="joint">The joint whose target rotation is to be set</param>
    /// <param name="currentRotation">The orientation you would like the joint to be in</param>
    /// <param name="originalRotation">The original orientation of the joint</param>
    public static void SetTargetRotation(ConfigurableJoint joint, Quaternion currentRotation, Quaternion originalRotation) {
        joint.targetRotation = Quaternion.identity * (originalRotation * Quaternion.Inverse(currentRotation));
    }

}
