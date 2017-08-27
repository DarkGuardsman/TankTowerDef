using UnityEngine;
using System.Collections;

/*
 * Data object to store a single unit spawn for a wave * 
 */
[System.Serializable]
public class EnemyWaveEntry : System.Object
{
    /** What to spawn */
    public GameObject prefabToSpawn;

    /** Total amount to spawn */
    public int numberToSpawn;

    public int numberSpawnedSoFar = 0;

    /** Amount to spawn in a single run */
    public int spawnGroup = 1;
}