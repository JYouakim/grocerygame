using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoneController : MonoBehaviour
{
    Transform ragdollBone;
    public Transform targetedBone;
    // Start is called before the first frame update
    void Start()
    {
        ragdollBone = gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetedBone.position = ragdollBone.position;
        targetedBone.rotation = ragdollBone.rotation;
    }
}
