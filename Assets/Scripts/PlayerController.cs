using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float carSpeed = 20.0f;
    [SerializeField] float turnSpeed = 25.0f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle here
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
