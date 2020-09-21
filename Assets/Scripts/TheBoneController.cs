using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoneController : MonoBehaviour
{
    Transform ragdollBone;
    public Transform targetedBone;
    private ConfigurableJoint boneJoint;
    private JointDrive livingJointX = new JointDrive();
    private JointDrive livingJointYZ = new JointDrive();
    private JointDrive deadJoint = new JointDrive();

    // Start is called before the first frame update
    void Start()
    {
        ragdollBone = gameObject.transform;
        boneJoint = this.gameObject.GetComponent<ConfigurableJoint>();

        if (boneJoint != null)
        {
            livingJointX.positionSpring = boneJoint.angularXDrive.positionSpring;
            livingJointX.maximumForce = Mathf.Infinity;
            livingJointX.positionDamper = boneJoint.angularXDrive.positionDamper;
            livingJointYZ.positionSpring = boneJoint.angularYZDrive.positionSpring;
            livingJointYZ.maximumForce = Mathf.Infinity;
            livingJointYZ.positionDamper = boneJoint.angularYZDrive.positionDamper;

            deadJoint.positionSpring = 0;
            deadJoint.maximumForce = Mathf.Infinity;
            deadJoint.positionDamper = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetedBone.position = ragdollBone.position;
        targetedBone.rotation = ragdollBone.rotation;
    }

    void Update()
    {
        if (boneJoint != null)
        {
            if (Input.GetButtonDown("Ragdoll"))
            {
                boneJoint.angularXDrive = deadJoint;
                boneJoint.angularYZDrive = deadJoint;
            }

            if (Input.GetButtonUp("Ragdoll"))
            {
                boneJoint.angularXDrive = livingJointX;
                boneJoint.angularYZDrive = livingJointYZ;
            }
        }
    }
}
