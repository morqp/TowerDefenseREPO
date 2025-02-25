using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private bool keepSpawning = true;

    [SerializeField] private int spawnIntervalInSeconds = 5;


    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while(keepSpawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnIntervalInSeconds);
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,transform.position, transform.rotation);
    }

}

