using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class TurretControl : PlayerControl
{
    public float yawSpeed = 150.0f;

    float yaw;

    // Update is called once per frame
    void Update()
    {
        if (!IsControlPaused())
        {
            yaw = CrossPlatformInputManager.GetAxis("Mouse X") * Time.deltaTime * yawSpeed;
        }
    }

    void FixedUpdate()
    {
        if (!IsControlPaused())
        {
            transform.Rotate(0, yaw, 0);
        }
    }
}
