using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Create a boundary variable
    private float topBound = 30.0f;

    // Create a lower boundary variable for animals
    private float lowerBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Projectile drifts past the play area into eternity
        // in order to improve game performance, we need to destroy them
        // when they go out of bounds
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // Destroy animals when they go out of bounds
        else if(transform.position.z < lowerBound)
        {   // Trigger Game Over message
            Debug.Log("Game Over!!");
            Destroy(gameObject);
        }
    }
}
