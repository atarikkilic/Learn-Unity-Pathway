using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float horsePower = 0;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // add a speed variable for vehicle, we can change the vehicle's speed

    //[SerializeField] private const float speed = 20.0f;

    // Create the turnSpeed variable
    [SerializeField] private float turnSpeed = 45.0f;

    // Create the horizontal input variable for direction
    private float horizontalInput;

    // Create the vertical input variable for control of the vehicle speed
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the axis that's horizontal  so we can get those left and right arrow keys
        horizontalInput = Input.GetAxis("Horizontal");

        // Get the axis that's vertical so we can get those up and down arrow keys
        verticalInput = Input.GetAxis("Vertical");

        // We'll move the vehicle forward
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward );
        //transform.Translate(Vector3.forward * Time.deltaTime * 20);


        if (IsOnGround())
        {                  
        // Moves the car forward based on vertical input

        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        // Rotates the car based on horizontal input

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + " kmh");

        rpm = (speed % 30) * 40;
        rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
