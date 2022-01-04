using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speedPizza = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Give the projectile some forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * speedPizza);
    }
}
