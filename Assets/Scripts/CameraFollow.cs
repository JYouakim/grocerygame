using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform angleTarget;
    public Camera mainCamera;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, target.position, smoothSpeed);

        if(!Input.GetButton("Ragdoll"))
        {
            mainCamera.transform.position = smoothedPosition;
        }

        mainCamera.transform.LookAt(angleTarget);
    }
}
