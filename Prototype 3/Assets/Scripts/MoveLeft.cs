using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 20;
    private PlayerController player;
    private float leftBound = -10;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("IncreaseSpeed", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (player.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed );
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void IncreaseSpeed()
    {
        speed += 2;
    }
}
