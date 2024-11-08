using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab; 
    public int numberOfMonstersToSpawn = 5;
    public float spawnDelay = 1f; 

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonstersToSpawn; i++)
        {
            SpawnMonster();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnMonster()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0f);
        
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
