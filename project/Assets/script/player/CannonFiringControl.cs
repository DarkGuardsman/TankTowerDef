using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CannonFiringControl : PlayerControl
{
    public float maxRayTrace = 1000;

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    public float bulletVelocity = 60f;
    public float bulletDeathTimer = 2f;

    public Vector3 aimDirection;
    public Vector3 hitPoint;
    public float distanceToHit;

    public float pitch;

    void Update()
    {
        //If running, get data for aiming the shot fired and estimating hit values
        if (!IsControlPaused())
        {
            //Get current aim of the cannon
            aimDirection = transform.TransformDirection(Vector3.down);

            //Get current expected hit point of the cannon
            RaycastHit hit;
            if(Physics.Raycast(transform.position, aimDirection, out hit, maxRayTrace))
            {
                //Get distance
                distanceToHit = hit.distance;

                //Get hit point
                hitPoint = hit.transform.position;
            }
        }
    }

    void FixedUpdate()
    {
        if (!IsControlPaused())
        {
            //TODO move to cannon script
            if (CrossPlatformInputManager.GetButton("Fire1"))
            {
                Debug.Log("TurretControl: Fired Weapon");
                player.CmdSpawn(bulletPrefab, bulletSpawn, bulletVelocity, bulletDeathTimer);
            }
        }
    }
}
