using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prot4PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody playerRb;
    public GameObject focalPoint;
    public bool hasPowerUp = false;
    public float powerUpStrength = 15f;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0f); 
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDownTimer());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyDir = enemyRigidBody.position - transform.position;
            enemyRigidBody.AddForce(enemyDir * powerUpStrength, ForceMode.Impulse);
           
        }
    }

    IEnumerator PowerUpCountDownTimer()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
