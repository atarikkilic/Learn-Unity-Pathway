using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Create array and store the animals
    public GameObject[] animalPrefabs;

    // Create location variable for random spawn loc
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;

    //public int animalIndex;


    // Create variables for timed intervals
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Use InvokeRepeating to spawn the animals based on an interval
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
           // Spawn animal randomly
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ), animalPrefabs[animalIndex].transform.rotation);
        
    }
}
