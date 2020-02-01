using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Smooth_Locomotion : MonoBehaviour
{
    public SteamVR_Action_Vector2 stickInput;
    public float speed = 1.0f;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = Player.instance.moveHandTransform.TransformDirection(new Vector3(stickInput.axis.x, 0, stickInput.axis.y));
        transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(inputDirection, Vector3.up);
    }
}
