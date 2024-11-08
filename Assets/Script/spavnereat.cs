using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spavnereat : MonoBehaviour
{
    public GameObject eat1Prefab;
    public GameObject eat2Prefab;
    public GameObject eat3Prefab;

    public int maxSpawns = 10;
    private int currentSpawnCount = 0; 

    public float spawnInterval = 2f;
    private float nextSpawnTime = 0f;
    public static bool AllSpawned = false;

    void Update()
    {
        if (currentSpawnCount < maxSpawns && Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);

            int randomIndex = Random.Range(0, 3); 

            if (randomIndex == 0)
            {
                Instantiate(eat1Prefab, spawnPosition, Quaternion.identity);
            }
            else if (randomIndex == 1)
            {
                Instantiate(eat2Prefab, spawnPosition, Quaternion.identity);
            }
            else if (randomIndex == 2)
            {
                Instantiate(eat3Prefab, spawnPosition, Quaternion.identity);
            }

            currentSpawnCount++; 
            nextSpawnTime = Time.time + spawnInterval;
        }
        if (currentSpawnCount >= maxSpawns)
        {
            GameObject[] eats1 = GameObject.FindGameObjectsWithTag("eat1");
            GameObject[] eats2 = GameObject.FindGameObjectsWithTag("eat2");
            GameObject[] eats3 = GameObject.FindGameObjectsWithTag("eat3");

            GameObject[] allEats = eats1.Concat(eats2).Concat(eats3).ToArray();

            if (allEats.Length == 0)
            {
                AllSpawned = true;
            }
        }
    }
}
