using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Controls spawners and handles wave creation
 */
public class EnemySpawnController : MonoBehaviour {

    public EnemySpawner[] spawners;
    public EnemyWave[] waves;
    public int[] delayBetweenWaves;

    public Transform moveGoal;

    public double time = 0;

    public int currentWave = 0;
	
	void Start ()
    {
		
	}	
	
	void FixedUpdate ()
    {
        time += Time.deltaTime; 
	}
}