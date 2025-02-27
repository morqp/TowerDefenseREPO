using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves;                // List of waves set up in the Inspector
    public float pauseBetweenWaves = 5f;      // Extra pause after all enemies are cleared
    public EnemySpawner enemySpawner;       // Reference to the EnemySpawner

    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(RunWaves());
    }


    IEnumerator RunWaves()
    {
        while (currentWaveIndex < waves.Count)
        {
            Wave currentWave = waves[currentWaveIndex];
            Debug.Log("Starting Wave: " + currentWave.waveName);

            // Spawn all enemies for the current wave.
            yield return StartCoroutine(SpawnWave(currentWave));

            // Wait until all spawned enemies are destroyed.
            yield return new WaitUntil(() => AllEnemiesCleared());

            // Pause after clearing the wave, giving the player time to act.
            Debug.Log("Wave complete. Pausing for " + pauseBetweenWaves + " seconds.");
            yield return new WaitForSeconds(pauseBetweenWaves);

            currentWaveIndex++;
        }

        Debug.Log("All waves complete!");
    }

    // Spawns the enemies for a given wave.
    IEnumerator SpawnWave(Wave wave)
    {
        // Build a list of enemy prefabs based on the configured counts.
        List<GameObject> spawnList = new List<GameObject>();
        foreach (EnemySpawnConfig config in wave.enemySpawnConfigs)
        {
            for (int i = 0; i < config.count; i++)
            {
                spawnList.Add(config.enemyPrefab);
            }
        }

        // Optional: Shuffle the list to interleave enemy types.
        ShuffleList(spawnList);

        // Spawn each enemy with a delay defined by spawnInterval.
        foreach (GameObject enemyPrefab in spawnList)
        {
            enemySpawner.SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(wave.spawnInterval);
        }
    }

    // Checks if all enemies (tagged as "Enemy") are destroyed.
    bool AllEnemiesCleared()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    // Fisher-Yates shuffle to randomize the enemy spawn order.
    void ShuffleList(List<GameObject> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
