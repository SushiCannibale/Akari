using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothness = 10.0f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 finalposition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, finalposition, smoothness * Time.deltaTime);
        transform.position = smoothed;
        
        transform.LookAt(target); // C la magie :O
    }
}

