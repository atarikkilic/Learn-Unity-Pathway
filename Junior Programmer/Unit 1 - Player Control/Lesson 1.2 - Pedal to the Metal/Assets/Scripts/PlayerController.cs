using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // add a speed variable for vehicle, we can change the vehicle's speed
    
    private float speed = 20.0f;

    // Create the turnSpeed variable
    private float turnSpeed = 45.0f;

    // Create the horizontal input variable for direction
    private float horizontalInput;

    // Create the vertical input variable for control of the vehicle speed
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the axis that's horizontal  so we can get those left and right arrow keys
        horizontalInput = Input.GetAxis("Horizontal");

        // Get the axis that's vertical so we can get those up and down arrow keys
        verticalInput = Input.GetAxis("Vertical");

        // We'll move the vehicle forward
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward );
        //transform.Translate(Vector3.forward * Time.deltaTime * 20);

        // Moves the car forward based on vertical input

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        // Rotates the car based on horizontal input

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


    }
}
