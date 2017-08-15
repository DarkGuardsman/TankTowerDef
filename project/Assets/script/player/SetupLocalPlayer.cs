﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour 
{
    [SyncVar]
    string playerName = "player";
    
    public GameObject playerCamera;    
    
    void OnGUI()
    {
        if(isLocalPlayer)
        {
            playerName = GUI.TextField(new Rect (25, Screen.height - 40, 100, 30), playerName);
            if(GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(playerName);
            }
        }
    }
    
    [Command]
    public void CmdChangeName(string newName)
    {
        playerName = newName;
    }
    
	// Use this for initialization
	void Start () 
    {
        //https://www.youtube.com/watch?v=wvUNXkrEMys Add smooth camera following
		if(isLocalPlayer)
        {
            GetComponent<drive>().enabled = true;
            playerCamera.SetActive(true);
        }
	}
    
    void Update()
    {
        this.GetComponentInChildren<TextMesh>().text = playerName;
    }
}
