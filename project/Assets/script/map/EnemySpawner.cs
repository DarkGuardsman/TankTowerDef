using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public Vector3 direction;

    void OnEnabled()
    {
        direction = transform.TransformDirection(Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction,  out hit, 100))
        {
            double distance = hit.distance;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, new Vector3(0, -100, 0));
    }

    // Use this for initialization
    void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {   
               
    }
}