using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MobSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] public int waveSize = 5;

    private float spawnTimer = 0f;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float rotationAngle = 15f;
    private int countObjectsSpawned = 0;
    [SerializeField] private int maxObjectsToSpawn = 30;
    [SerializeField] private float spawnRadius = 4f;

    private Vector3 rotationVector;

    //private CrowdControl crowdManager;

    private void Start()
    {
        //crowdManager = this.GetComponent<CrowdControl>();
        rotationVector = new Vector3(0, 1, 0) * spawnRadius;
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval & countObjectsSpawned < maxObjectsToSpawn)
        {
            spawnTimer = 0f;

            SpawnClockwise();
        }
    }

    void SpawnClockwise()
    {
        rotationVector = Quaternion.Euler(0, 0, rotationAngle) * rotationVector;

        Vector3 spawnPosition = this.transform.position + rotationVector;

        //draw spawn position
        Debug.DrawLine(this.transform.position, spawnPosition, Color.red);

        SpawnOneEnemy(spawnPosition);
    }

    void SpawnOneEnemy(Vector3 position)
    {
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity, this.transform);
        enemy.name = "enemy" + (countObjectsSpawned + 1);

        countObjectsSpawned++;
    }
}
