using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    public Camera singleCam;
    public Light singleLight;

    public float speed;
    public float jumpForce;
    public float rotationSmoothness;
    public double jumpThreshold;

    private bool isGrounded;
    
    private static Rigidbody rb;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
            
        // initialize fields
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
    }

    void UpdateJump(float yComp)
    {
        isGrounded = yComp <= jumpThreshold && yComp >= -jumpThreshold;
        
        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    void Update()
    {
        Vector3 vel = rb.velocity;

        Transform t = singleCam.transform;
        Vector3 forward = t.forward;
        Vector3 side = t.right;

        forward.Set(forward.x, 0, forward.z);
        forward *= Input.GetAxis("Vertical") * speed;
        
        side.Set(side.x, 0, side.z);
        side *= Input.GetAxis("Horizontal") * speed;
        
        vel.x = forward.x + side.x;
        UpdateJump(vel.y);
        vel.z = forward.z + side.z;
        
        rb.velocity = vel;

        /* Le player fait face au sens de son mouvement */
        if (vel != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(-(forward + side).normalized);
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, targetRot, rotationSmoothness * Time.deltaTime);
        }
    }
}
