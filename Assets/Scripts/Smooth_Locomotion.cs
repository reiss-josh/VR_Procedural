using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Smooth_Locomotion : MonoBehaviour
{
    public SteamVR_Action_Vector2 stickInput;
    public float speed = 1.0f;
    public float gravity = 5.0f;
    private CharacterController charController;
    public Transform cameraTransform;
    public Transform bodyTransform;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 diff = (cameraTransform.position - bodyTransform.position);
        Vector3 diffnoY = new Vector3((diff.x), charController.center.y, (diff.z));
        charController.center = diffnoY;
        Vector3 inputDirection = Player.instance.moveHandTransform.TransformDirection(new Vector3(stickInput.axis.x, 0, stickInput.axis.y));
        charController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(inputDirection, Vector3.up) - new Vector3(0,gravity,0)*Time.deltaTime);
    }
}
