using UnityEngine;
using System.Collections;
using System;

public class NodeMap : MonoBehaviour
{   
    public Vector3 direction;

    public Vector3 targetPoint;

    public Transform moveGoal;

    public virtual void OnEnable()
    {
        direction = transform.TransformDirection(Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 100))
        {
            float distance = hit.distance;
            targetPoint = new Vector3(transform.position.x, transform.position.y - distance + getRayOffsetY(), transform.position.z);
        }
    }

    protected virtual int getRayOffsetY()
    {
        return 0;
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, new Vector3(0, -100, 0));
    }

    public Transform getMovePosition()
    {
        return moveGoal != null ? moveGoal : transform;
    }
}
