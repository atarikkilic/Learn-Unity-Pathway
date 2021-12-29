using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // camera's current transform position set that to
        // the current position of our player's transform component
        // Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + new Vector3(0.01f, 4.4f, -7.2f);
    }
}
