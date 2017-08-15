using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour 
{	
	// Update is called once per frame
	void Update () 
    {
        Camera cam =  Camera.current;
        if(cam != null)
        {
            transform.LookAt(cam.transform.position);
            transform.Rotate(new Vector3(0, 180, 0));
        }
	}
}
