using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spavnerpronos : MonoBehaviour
{
    public GameObject eat1Prefab;
    public int maxSpawns = 0;
    private int currentSpawnCount = 0; 

    public float spawnInterval = 2f;
    private float nextSpawnTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (currentSpawnCount < maxSpawns && Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);

            
                Instantiate(eat1Prefab, spawnPosition, Quaternion.identity);
        

            currentSpawnCount++; 
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
