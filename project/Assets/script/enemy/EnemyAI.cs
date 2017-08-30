using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public Transform moveGoal;
    public NavMeshAgent agent;

    public float distanceToKeepToTarget = 2;

    public float distanceToTarget;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        //TODO find player to attack
        if (moveGoal != null )
        {
            //Calc distance each tick
            distanceToTarget = Vector3.Distance(moveGoal.position, transform.position);

            //Update navigation path
            if (agent != null && !agent.hasPath)
            {
                //Path to goal as long as distance is far               
                if (distanceToTarget > distanceToKeepToTarget)
                {
                    agent.destination = moveGoal.position;
                }
                //Get next goal
                else
                {
                    //Get next path from current path goal
                    GameObject gameObject = moveGoal.gameObject;
                    Debug.Log("EnemyAI: " + gameObject);
                    if (gameObject)
                    {
                        //Try getting path from transform
                        NodePath path = gameObject.GetComponent<NodePath>();
                        Debug.Log("EnemyAI: P1 = " + path);
                        if (path)
                        {
                            path = path.nextPoint;
                            if (path)
                            {
                                moveGoal = path.getMovePosition();
                                agent.destination = moveGoal.position;
                            }
                        }

                        //Try getting path from parent
                        path = gameObject.GetComponentInParent<NodePath>();
                        Debug.Log("EnemyAI: P2 = " + path);
                        if (path)
                        {
                            path = path.nextPoint;
                            if (path)
                            {
                                moveGoal = path.getMovePosition();
                                agent.destination = moveGoal.position;
                            }
                        }
                    }
                }
            }
        }

        //Get targets to attack

        //Do health updates
    }
}
