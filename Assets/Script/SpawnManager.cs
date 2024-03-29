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
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection += spawnPosition.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, 1);
        Instantiate(enemyController, hit.position, Quaternion.identity);
    }
}
