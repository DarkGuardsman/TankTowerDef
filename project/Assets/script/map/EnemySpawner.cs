using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : MonoBehaviour 
{
    public Transform moveGoal;

    public Vector3 direction;

    public EnemyWave[] waves;

    public int currentWave;
    public bool doneWithWave;

    public Vector3 spawnPoint;
    public Quaternion spawnRotation = Quaternion.identity;

    void OnEnable()
    {
        direction = transform.TransformDirection(Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction,  out hit, 100))
        {
            float distance = hit.distance;
            spawnPoint = new Vector3(transform.position.x, transform.position.y - distance + 1, transform.position.z);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, new Vector3(0, -100, 0));
    }

    public void DoSpawning()
    {
        if(!HasCompletedWave())
        {
            EnemyWave wave = waves[currentWave];
            if(!wave.IsCompleted())
            {
                EnemyWaveEntry entry = wave.CurrentSetToSpawn();
                bool spawnedUnits = false;

                //Spot trying to spawn if we spawn something or are out of things to spawn
                while(!spawnedUnits && !wave.IsCompleted())
                {
                    if(entry == null || entry.numberSpawnedSoFar >= entry.numberToSpawn)
                    {
                        wave.InitNext();
                    }
                    else
                    {
                        SpawnUnit(entry.prefabToSpawn);
                        entry.numberSpawnedSoFar++;
                    }
                }                
            }
            else
            {
                Debug.Log("EnemySpawner: Done with wave " + currentWave);
                doneWithWave = true;
            }
        }
    }
   
    public void SpawnUnit(GameObject prefabToSpawnNext)
    {
        Debug.Log("EnemySpawner: Spawning unit " + prefabToSpawnNext);

        // create server-side instance
        GameObject obj = Instantiate(prefabToSpawnNext, GetSpawnPoint(), GetSpawnRotation()) as GameObject;

        EnemyAI enemy = obj.GetComponent<EnemyAI>();
        if(enemy != null)
        {
            enemy.moveGoal = moveGoal;
        }
        else
        {
            Debug.Log("EnemySpawner#SpawnUnit() >> Failed to set AI move target");
        }

        // spawn on the clients
        NetworkServer.Spawn(obj);
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint;
    }

    public Quaternion GetSpawnRotation()
    {
        return spawnRotation;
    }

    public void InitWave(int waveIndex)
    {
        currentWave = waveIndex;
        doneWithWave = false;

        if(currentWave < waves.Length)
        {
            EnemyWave wave = waves[currentWave];
            if(wave != null)
            {
                //Reset wave spawn count in case we are looping over again
                foreach(EnemyWaveEntry entry in wave.setsToSpawn)
                {
                    entry.numberToSpawn = 0;
                }
            }
        }
    }

    public bool HasCompletedWave()
    {
        return currentWave >= waves.Length || waves[currentWave] == null || doneWithWave;
    }
}
