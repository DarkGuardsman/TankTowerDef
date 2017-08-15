using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//Handles controls for the tank
public class drive : MonoBehaviour {
    
    // Settings
    public float speed = 1F;
	
	// Update is called once per frame
	void Update () {
        
        //Forward/Backwards movement
		float tranlation = CrossPlatformInputManager.GetAxis("Vertical") * speed;        
        transform.Translate(0, 0, tranlation);
        
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        transform.Rotate(0, rotation, 0);
        
	}
}
