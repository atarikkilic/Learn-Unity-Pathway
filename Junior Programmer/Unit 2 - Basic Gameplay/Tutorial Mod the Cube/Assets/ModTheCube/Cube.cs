using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float timer = 0;

    void Start()
    {
        transform.position = new Vector3(6, 7, 1); // Change the cube's location (transform)
        transform.localScale = Vector3.one * 1.5f; // Change the cube's scale

        Material material = Renderer.material;

        //material.color = new Color(0.3f, 0.4f, 0.5f, 0.6f); // Change the cube’s material color

        // Change the cube’s material color randomly each time the scene is played.
        material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    
    void Update()
    {
        // Change the angle at which the cube rotates
        // Change the cube’s rotation speed.
        transform.Rotate(0.0f, 15.0f * Time.deltaTime, 0.0f);
        ColorChanger();
    }

    // Change the color of the cube every 5 sec
    void ColorChanger()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Renderer.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            timer = 0;
        }

    }
}
