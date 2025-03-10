using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 10;
    // Start is called before the first frame update
    void Start()
    {
        
       
        Instantiate (enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
       
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos; 
    }
         
}
