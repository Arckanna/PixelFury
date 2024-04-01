using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRadius;
    [SerializeField] Transform spawnPosition;

    // Start is called before the first frame update
    float spawnTimer;
    

    // Update is called once per frame
    void Update()
    {
       spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
              SpawnEnemy();
              spawnTimer = spawnRate;
         }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyController, spawnPosition.position + Random.insideUnitSphere * spawnRadius, Quaternion.identity);
    }
}
