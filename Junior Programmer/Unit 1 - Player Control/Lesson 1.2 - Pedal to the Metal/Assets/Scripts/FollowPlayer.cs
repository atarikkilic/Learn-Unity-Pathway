using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    // Get a reference to an object in the scene for another object to use
    public GameObject player;

    // create a variable for accessing the offset
    [SerializeField] private Vector3 offset = new Vector3(0.01f, 4.4f, -7.2f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    // LateUpdate for will then move our camera after the vehicle is moved.
    void LateUpdate()
    {
        // camera's current transform position set that to
        // the current position of our player's transform component
        // Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset ;
    }
}
