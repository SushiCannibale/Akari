using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerPlayer : NetworkBehaviour
{
    // [SerializeField] private ServerCamera cam;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    
    // public Vector3 hitOffset;
    // public float hitRange = 0.5f;
    // public LayerMask hitLayer;

    public float rotationSmoothness;
    public float jumpStrength;
    public float gravity = -9.81f;
    
    private float yVel;
    private bool canJump;

    // public override void OnGainedOwnership()
    // {
    //     cam.gameObject.SetActive(true);
    // }

    /* Client authoritative movement */
    void Update()
    {
        if (!IsOwner)
            return;

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed * Time.deltaTime;

        // Transform camT = cam.transform;
        // Vector3 fwd = camT.forward;
        // Vector3 side = camT.right;
        //
        // fwd *= Input.GetAxis("Vertical") * speed;
        // side *= Input.GetAxis("Horizontal") * speed;
        //
        // Vector3 planeDir = fwd + side;
        // planeDir.y = 0;
        //
        // Vector3 yDir = new Vector3(0, 0, 0);
        //
        // HandleMove(ref yDir);
        //
        // controller.Move((planeDir + yDir) * Time.deltaTime);
        //
        // if (planeDir != Vector3.zero)
        // {
        //     Quaternion toRot = Quaternion.LookRotation(-planeDir, Vector3.up);
        //     controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
        // }

        // Vector3 dir = new Vector3();
        // if (Input.GetKey(KeyCode.Z)) dir.z = +1f;
        // if (Input.GetKey(KeyCode.S)) dir.z = -1f;
        //
        // if (Input.GetKey(KeyCode.LeftShift)) dir.y = -1f;
        // if (Input.GetKey(KeyCode.Space)) dir.y = +1f;
        //
        // if (Input.GetKey(KeyCode.Q)) dir.x = -1f;
        // if (Input.GetKey(KeyCode.D)) dir.x = +1f;
        //
        // transform.position += dir * 3f * Time.deltaTime;
    }
    
    private void HandleMove(ref Vector3 yDir)
    {
        if (controller.isGrounded)
        {
            yVel = 0;
            canJump = true;
        }
        
        if (Input.GetButtonDown("Jump") && canJump)
        {
            yVel += jumpStrength;
            canJump = false;
        }
        
        yVel += gravity * Time.deltaTime;
        yDir.y += yVel;
    }
}
