using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Smooth_Locomotion : MonoBehaviour
{
    public Rigidbody rb2d;
    public bool rightHanded = false;
    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public Transform movementHandTF = null;

    public float m_Sensitivity = 1.0f;
    public float m_MaxSpeed = 1.0f;

    private float m_Speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 orientationEuler = new Vector3(0, movementHandTF.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
            m_Speed = 0;
        
        if(m_MovePress.state)
        {
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);

            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }
        //Apply
        
    }
}
