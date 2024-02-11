using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] public int numberOfEnemiesToSpawn = 5;

    private float spawnTimer = 0f;
    [SerializeField] private float spawnInterval = 1f;
    private int countObjectsSpawned = 0;
    [SerializeField] private int maxObjectsToSpawn = 30;
    [SerializeField] private float spawnRadius = 4f;

    //private CrowdControl crowdManager;

    private void Start()
    {
        //crowdManager = this.GetComponent<CrowdControl>();
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval & countObjectsSpawned < maxObjectsToSpawn)
        {
            spawnTimer = 0f;

            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x + i * spawnRadius, transform.position.y + i * spawnRadius, transform.position.z + i * spawnRadius), Quaternion.identity, this.transform);

            enemy.name = "enemy" + (i + 1);
            countObjectsSpawned++;
        }
    }
}
