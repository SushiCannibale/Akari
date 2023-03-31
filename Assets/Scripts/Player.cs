using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : AbstractInterScene
{
    [SerializeField] private Camera singleCam;
    [SerializeField] private Light singleLight;
    public float speed;
    public float rotationSmoothness;
    public float jumpStrength;
    public float gravity = -9.81f;
    
    private float yVel = 0f;
    private bool canJump = false;

    private CharacterController controller;

    // private bool canMove = true;
    
    /* Cheats */
    private bool MoonJump;
    public bool GetMoonJump() => MoonJump;
    public void SetMoonJump(bool value) => MoonJump = value;

    private bool NoClip;
    public bool GetNoclip() => NoClip;

    public void SetNoClip(bool value)
    {
        NoClip = value;
    }

    /* *** */

    private void Start()
    {
        // LevelTriggerer.PlayerEnterZone += PreventMove;
        // LevelTriggerer.PlayerExitZone += AllowMove;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Transform camT = singleCam.transform;
        Vector3 fwd = camT.forward;
        Vector3 side = camT.right;

        fwd *= Input.GetAxis("Vertical") * speed;
        side *= Input.GetAxis("Horizontal") * speed;

        Vector3 planeDir = fwd + side;
        planeDir.y = 0;

        Vector3 yDir = new Vector3(0, 0, 0);

        MovementUpdate(ref yDir);
        
        controller.Move((planeDir + yDir) * Time.deltaTime);
        
        /* Le joueur regarde dans la direction de son mouvement */
        if (planeDir != Vector3.zero)
        {
            Quaternion toRot = Quaternion.LookRotation(-planeDir, Vector3.up);
            controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
        }
    }
    
    /************************************/
    /* Fonctions appelés par des events */
    /************************************/

    // private void PreventMove(string zoneTag, string __)
    // {
    //     if (zoneTag.Equals("DarkZone"))
    //         canMove = false;
    // }

    // private void AllowMove(string zoneTag, string __)
    // {
    //     if (zoneTag.Equals("DarkZone"))
    //         canMove = true;
    // }

    private void MovementUpdate(ref Vector3 yDir)
    {
        if (NoClip)
        {
            if (Input.GetButton("Jump"))
            {
                yDir.y += speed;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                yDir.y -= speed;
            }
        }
        else
        {
            if (controller.isGrounded)
            {
                yVel = 0;
                canJump = true;
            }

            if (Input.GetButtonDown("Jump") && (canJump || MoonJump))
            {
                yVel += jumpStrength;
                canJump = false;
            }
        
            yVel += gravity * Time.deltaTime;
            yDir.y += yVel;
        }
    }
}
