using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public float smoothness = 10.0f;
    public Vector3 offset;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetTarget(Transform transform) => target = transform;
    private void LateUpdate()
    {
        if (target == null)
            return;
        
        Vector3 finalposition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, finalposition, smoothness * Time.deltaTime);
        transform.position = smoothed;
        
        transform.LookAt(target);
    }
}

