﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Smooth_Locomotion : MonoBehaviour
{
    public SteamVR_Action_Vector2 stickInput;
    public SteamVR_Action_Boolean jumpButton;
    public VoxelMap voxMap; //specific to this project
    //private CharacterController controller;
    private Vector3 stickDir = Vector3.zero;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Transform cameraPos;
    private Vector3 lastFrameCam = Vector3.zero;
    private Vector3 midPointTravel;

    void Start()
    {
        midPointTravel = new Vector3(voxMap.midPoint, voxMap.midPoint * 2, voxMap.midPoint);
        transform.localPosition = midPointTravel;
    }

    void Update()
    {
        midPointTravel = new Vector3(voxMap.midPoint, voxMap.midPoint * 2, voxMap.midPoint);
        transform.position = Vector3.zero;
        Vector3 inputDirection = Player.instance.moveHandTransform.TransformDirection(new Vector3(stickInput.axis.x, 0, stickInput.axis.y));
        stickDir = Vector3.ProjectOnPlane(inputDirection, Vector3.up); //stick movement
        CharacterController controller = GetComponent<CharacterController>();

        //update player coordinates based on change in camera position
        Debug.Log(cameraPos.localPosition);
        transform.localPosition += cameraPos.localPosition;

        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = stickDir;
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            //if (Input.GetButton("Jump"))
            if(jumpButton.GetState(SteamVR_Input_Sources.Any))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
