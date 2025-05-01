using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject powerUPrefab;
    private float spawnRange = 10;
    private int EnemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUPrefab, GenerateSpawnPosition(), powerUPrefab.transform.rotation);
        SpawnEnemy(waveNumber);
    }

    private void SpawnEnemy(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {

            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<EnemyScript>().Length;
        if (EnemyCount < 1) {
            SpawnEnemy(waveNumber);
            Instantiate(powerUPrefab, GenerateSpawnPosition(), powerUPrefab.transform.rotation);
            waveNumber++;
        }
    }
}
