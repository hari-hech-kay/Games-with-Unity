using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float startDelay = 2;
    private float repeatRate = 2;
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController player;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (player.gameOver == false)
        {
            GameObject obstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }

    void ReduceRepeat()
    {
        if (repeatRate > 0.4f)
        {
            repeatRate -= 0.4f;
        }
    }
}
