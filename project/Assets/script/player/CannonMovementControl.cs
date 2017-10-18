using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CannonMovementControl : PlayerControl
{
    public float pitchSpeed = 3.0f;

    public float pitch;

    // Update is called once per frame
    void Update()
    {
        if (!IsControlPaused())
        {
            pitch = -CrossPlatformInputManager.GetAxis("Mouse Y") * Time.deltaTime * pitchSpeed;
        }
    }

    void FixedUpdate()
    {
        if (!IsControlPaused())
        {
            transform.Rotate(pitch, 0, 0);
        }
    }
}
