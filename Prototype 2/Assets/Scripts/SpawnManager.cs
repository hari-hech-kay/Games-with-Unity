using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnPosX;
    private float spawnPosZ = 25;
    public GameObject[] animalPrefabs;
    private int animalIndex;
    private float spawnTime = 2;
    private float spawnDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0, animalPrefabs.Length);
        spawnPosX = Random.Range(-10, 11);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
