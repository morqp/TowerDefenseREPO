using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string waveName;                         
    public float spawnInterval = 1f;                  
    public List<EnemySpawnConfig> enemySpawnConfigs;  
}
