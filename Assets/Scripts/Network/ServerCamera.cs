using System;
using Unity.Netcode;
using UnityEngine;

public class ServerCamera : NetworkBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothness = 10.0f;
    public Vector3 offset;

    public override void OnGainedOwnership()
    {
        gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        if (!IsOwner)
            return;
        
        Vector3 finalposition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, finalposition, smoothness * Time.deltaTime);
        transform.position = smoothed;
        
        transform.LookAt(target);
    }
}