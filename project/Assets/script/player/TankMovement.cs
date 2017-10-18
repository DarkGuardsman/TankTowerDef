﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//Handles controls for the tank
public class TankMovement : PlayerControl
{    
    // Settings
    public float moveSpeed = 1F;
    public float turnSpeed = 1F;
    
    private float tranlation;    
    private float rotation;
	
	// Update is called once per frame
	void Update () {

        if (!IsControlPaused())
        {
            //Forward/Backwards movement
            tranlation = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
            rotation = CrossPlatformInputManager.GetAxis("Horizontal") * turnSpeed;
        }
	}
    
    void FixedUpdate ()
    {
        if (!IsControlPaused())
        {
            transform.Translate(0, 0, tranlation);
            transform.Rotate(0, rotation, 0);
        }
    }
}
