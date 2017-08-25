using UnityEngine;
using System.Collections;

/**
 * Data object to store a single spawn set for a single enemy spawner
 */
[System.Serializable]
public class EnemyWave : System.Object
{
    /** Units to spawn this wave */
    public EnemyWaveEntry[] setsToSpawn;
}