using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class PlayerCamera : MonoBehaviour, IPersistentData
{
    [SerializeField] Transform target;
    [SerializeField] private float smoothness = 10.0f;
    public Vector3 offset;
    
    private void LateUpdate()
    {
        if (target is null)
            return;
        
        Vector3 finalposition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, finalposition, smoothness * Time.deltaTime);
        transform.position = smoothed;
        
        transform.LookAt(target);
    }

    public void LoadFrom(GameData data)
    {
        offset = data.camOffset;
    }

    public void SaveTo(GameData data)
    {
        data.camOffset = offset;
    }
}

