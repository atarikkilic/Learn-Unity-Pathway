using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitZLeft = 0;
    private float spawnLimitZRight = 33;
    private float spawnPosY = 30;
    private float spawnPosX = 22.58f;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Make the spawn interval a random value between 3 seconds and 5 seconds
        InvokeRepeating("SpawnRandomBall", startDelay, Random.Range(spawnInterval - 1, spawnInterval + 1));
    }

    // Spawn random ball at random z position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(-spawnPosX, spawnPosY, Random.Range(spawnLimitZLeft, spawnLimitZRight));

        // instantiate ball at random spawn location
        // Spawn ball randomly
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
