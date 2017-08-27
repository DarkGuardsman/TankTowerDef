using UnityEngine;
using System.Collections;
using System;

/**
 * Data object to store a single spawn set for a single enemy spawner
 */
[System.Serializable]
public class EnemyWave : System.Object
{
    /** Units to spawn this wave */
    public EnemyWaveEntry[] setsToSpawn;

    public int currentSet;

    public bool completedWave = false;

    public bool IsCompleted()
    {
        return completedWave || setsToSpawn == null || currentSet >= setsToSpawn.Length || setsToSpawn[currentSet] == null;
    }

    public EnemyWaveEntry CurrentSetToSpawn()
    {
        if(!IsCompleted())
        {
            return setsToSpawn[currentSet];
        }
        return null;
    }

    public void InitNext()
    {
        completedWave = false;
        currentSet++;
    }
}