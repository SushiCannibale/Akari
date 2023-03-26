using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera singleCam;
    [SerializeField] private Light singleLight;
    public float speed;
    public float rotationSmoothness;
    public float jumpStrength;
    public float gravity = -9.81f;

    private CharacterController controller;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Transform camT = singleCam.transform;
        Vector3 fwd = camT.forward;
        Vector3 side = camT.right;
        
        fwd.Set(fwd.x, 0, fwd.z);
        fwd *= Input.GetAxis("Vertical") * speed;
        
        side.Set(side.x, 0, side.z);
        side *= Input.GetAxis("Horizontal") * speed;

        Vector3 direction = fwd + side;

        if (controller.isGrounded)
        {
            // direction.y = 0f;
            // marche pas 
            if (Input.GetButtonDown("Jump"))
                direction.y += Mathf.Sqrt(jumpStrength * -0.3f * gravity);
        }

        // direction.y += gravity * Time.fixedDeltaTime;
        controller.SimpleMove(direction);
        
        /* Le joueur regarde dans la direction de son mouvement */
        if (direction != Vector3.zero)
        {
            Quaternion toRot = Quaternion.LookRotation(-direction, Vector3.up);
            controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
        }
    }
}
