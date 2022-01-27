using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ForceMode.Impulse - Applies an instant force on the Object, taking mass into account.
            //This pushes the Object using the entire force in a single frame.
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }
}
