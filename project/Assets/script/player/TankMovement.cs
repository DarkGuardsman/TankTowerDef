using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//Handles controls for the tank
public class TankMovement : PlayerControl
{        
    public MovementSystem movementSystem;

    //Called when object is activated
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (!IsControlPaused() && movementSystem != null)
        {
            movementSystem.SetMovementRatio(CrossPlatformInputManager.GetAxis("Vertical"));
            movementSystem.SetTurnRatio(CrossPlatformInputManager.GetAxis("Horizontal"));
        }
    }
    
    void FixedUpdate ()
    {
        
    }
}
