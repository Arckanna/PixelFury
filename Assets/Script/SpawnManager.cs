using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializedField] EnemyController enemyPrefab;
    [SerializedField] float spawnRate;
    [SerializedField] List<Transform> spawnPosition;

    private float spawnTimer = 0;
    
    

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0)
        {
            spawnTimer = spawnRate;
            SpawnEnemy();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
        Transform randomSpawnPosition = spawnPosition[Random.Range(0, spawnPosition.Count)];
        Instantiate(enemyPrefab, randomSpawnPosition.position, Quaternion.identity);
    }
}
