using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/**
 *  Controls spawners and handles wave creation
 */
public class EnemySpawnController : NetworkBehaviour {   

    public EnemySpawner[] spawners;   

    public double time = 0;

    public int currentWaveIndex = 0;
    public int maxWaves = -1;

    public bool completedWaves = false;
    public bool startSpawning = false;
    public bool repeatWaves = false;
	
	void OnEnable ()
    {
       foreach(EnemySpawner spawner in spawners)
       {
            if(spawner.waves.Length > maxWaves)
            {
                maxWaves = spawner.waves.Length;
            }
       }
    }	
	
	void FixedUpdate ()
    {
        if (startSpawning && !IsCompleted())
        {
            time += Time.deltaTime;
            if (time >= 10) //TODO calculate delay from spawners
            {
                time = 0;
                NextWave();
            }

            foreach (EnemySpawner spawner in spawners)
            {
                spawner.DoSpawning();
            }

            if(IsCompleted() && repeatWaves)
            {
                currentWaveIndex = -1;
            }
        }
	}

    public bool IsCompleted()
    {
        return completedWaves || currentWaveIndex >= maxWaves;
    }

    void NextWave()
    {
        currentWaveIndex++;

        Debug.Log("EnemySpawnController: Starting wave " + currentWaveIndex);

        if (currentWaveIndex >= maxWaves)
        {
            completedWaves = true;
            Debug.Log("EnemySpawnController: No waves left to start");
        }

        if (!completedWaves)
        {
            foreach (EnemySpawner spawner in spawners)
            {
                spawner.InitWave(currentWaveIndex);
            }
        }
    }
}