using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class TurretControl : NetworkBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);

		if (CrossPlatformInputManager.GetButton ("Primary")) {
			CmdFire ();
		}

	}

	[Command]
	void CmdFire()
	{

	}
}
