using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody player;
    private GameObject focalPoint;
    public float verticalInput;
    public float speed = 5;
    private bool hasPowerup = false;
    public GameObject powerupIndicator;
    public bool gameOver = false;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        player.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            float powerupStrength = 10;
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemy.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
