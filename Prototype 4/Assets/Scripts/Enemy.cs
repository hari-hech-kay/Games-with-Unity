﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 1;
    private Rigidbody enemy;
    private GameObject player;
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemy.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
