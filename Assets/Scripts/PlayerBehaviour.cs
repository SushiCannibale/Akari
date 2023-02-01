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
    public float friction;
    public Camera cam;
    
    // public float camDist;
    // private float phi = 45f;
    // private float theta = 35.264f;

    private Rigidbody rb;
    // private BoxCollider collider;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        var velo = rb.velocity;
        velo.x = Input.GetAxis("Horizontal") * speed;
        velo.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = velo;

        if (-2E-2f < rb.velocity.y && rb.velocity.y < 2E-2 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        
        UpdateCamera();
        // cam.transform.SetPositionAndRotation(cam.transform.position + new Vector3(velo.x * Time.deltaTime, 0, velo.z * Time.deltaTime), cam.transform.rotation);
    }

    private void UpdateCamera()
    {
        Vector3 p = rb.position;
        cam.transform.SetPositionAndRotation(new Vector3(p.x - 4f, p.y + 4f, p.z - 4f), cam.transform.rotation);
    }
}
