using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public Transform spawnPoint;  

    [SerializeField] private GameObject destination;
    
    public void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject newEnemyInstance = Instantiate(enemyPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

        newEnemyInstance.GetComponent<Enemy>().destination= destination;

    }
}
