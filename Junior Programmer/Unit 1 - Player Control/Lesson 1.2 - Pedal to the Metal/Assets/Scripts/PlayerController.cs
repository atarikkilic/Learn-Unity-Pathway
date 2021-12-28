using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // add a speed variable for vehicle, we can change the vehicle's speed
    // allow it to be accessed from the inspector
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We'll move the vehicle forward
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward );
        //transform.Translate(Vector3.forward * Time.deltaTime * 20);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        
    }
}
