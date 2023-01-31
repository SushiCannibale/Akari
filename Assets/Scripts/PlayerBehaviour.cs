using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public float jumpForce = 5;
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

    // Update is called once per frame
    void Update()
    {
        // Vector3 camPos = new Vector3((float)(-Math.Sin(phi) * Math.Sin(theta)), (float)(Math.Cos(phi) * Math.Sin(theta)), (float)Math.Sin(theta));
        // camPos *= camDist;
        // cam.transform.SetPositionAndRotation(camPos, new Quaternion(0, 0.1f, 0, 1));
        //rb.velocity = new Vector3(Input.GetAixs("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical")) * speed;
        
        var velo = rb.velocity;
        velo.x = Input.GetAxis("Horizontal") * speed;
        velo.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = velo;

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        
        cam.transform.SetPositionAndRotation(cam.transform.position, cam.transform.rotation);
    }
}
