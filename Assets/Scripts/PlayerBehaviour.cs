using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float rotationSmoothness;

    public Camera cam;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Vector3 velo = rb.velocity;
        // Vector3 moveDir = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        //
        // moveDir.Normalize();
        //
        // velo.x = Input.GetAxis("Horizontal") * speed;
        // velo.z = Input.GetAxis("Vertical") * speed;
        //
        // rb.velocity = velo;
        //
        // if (moveDir != Vector3.zero)
        // {
        //     Quaternion targetRot = Quaternion.LookRotation(moveDir, Vector3.up);
        //     rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, targetRot, rotationSmoothness * Time.deltaTime);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Space))
        //     rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        
        Vector3 vel = rb.velocity;

        Vector3 forward = cam.transform.forward;

        forward.Set(forward.x, 0, forward.z);
        forward *= Input.GetAxis("Vertical");
        
        Vector3 side = new Vector3(forward.z, forward.y, forward.x);
        side *= Input.GetAxis("Horizontal");
        
        vel.x = forward.x + side.x;
        vel.z = forward.z + side.z;
        
        rb.velocity = vel;

    }
}
