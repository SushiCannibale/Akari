using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerPlayer : NetworkBehaviour
{
    void Update()
    {
        if (!IsOwner)
            return;
        
        Vector3 dir = new Vector3();
        if (Input.GetKey(KeyCode.Z)) dir.z = +1f;
        if (Input.GetKey(KeyCode.S)) dir.z = -1f;
        
        if (Input.GetKey(KeyCode.LeftShift)) dir.y = -1f;
        if (Input.GetKey(KeyCode.Space)) dir.y = +1f;
        
        if (Input.GetKey(KeyCode.Q)) dir.x = -1f;
        if (Input.GetKey(KeyCode.D)) dir.x = +1f;
        
        transform.position += dir * 3f * Time.deltaTime;
    }
}
