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

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        Vector3 velo = rb.velocity;
        Vector3 moveDir = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));

        moveDir.Normalize();

        velo.x = Input.GetAxis("Horizontal") * speed;
        velo.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = velo;

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir, Vector3.up);
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, targetRot, rotationSmoothness * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }
}
