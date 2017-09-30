using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class TurretControl : PlayerControl
{
	public GameObject bulletPrefab;
	public GameObject bulletSpawn;

    public float yawSpeed = 150.0f;
    public float pitchSpeed = 3.0f;
    public float bulletVelocity = 60f;
    public float bulletDeathTimer = 2f;

	// Update is called once per frame
	void Update () {        

		float yaw = CrossPlatformInputManager.GetAxis("Rotate Body") * Time.deltaTime * yawSpeed;
		float pitch = CrossPlatformInputManager.GetAxis("Mouse Y") * Time.deltaTime * pitchSpeed;

		transform.Rotate (0, yaw, 0);
		transform.Rotate(pitch, 0, 0);

		if (CrossPlatformInputManager.GetButton ("Fire1"))
        {
            Debug.Log("TurretControl: Fired Weapon");
            player.CmdSpawn(bulletPrefab, bulletSpawn, bulletVelocity, bulletDeathTimer);
		}

	}
}
