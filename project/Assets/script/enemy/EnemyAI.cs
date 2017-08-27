using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public Transform moveGoal;
    public NavMeshAgent agent;

    public float distanceToKeepToTarget = 3;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        //TODO find player to attack
        if (moveGoal != null && agent != null && !agent.hasPath)
        {
            float dist = Vector3.Distance(moveGoal.position, transform.position);
            if (dist > distanceToKeepToTarget)
            {
                agent.destination = moveGoal.position;
            }//TODO add a delay to updating path and dead zone
        }
    }
}
