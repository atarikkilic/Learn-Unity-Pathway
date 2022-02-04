using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy goes toward up to player, always goes constant speed regardless of distance with .normalized
        // Normalize that entire vector,so that way it doesn't increase in magnitude the farther the two objects are away
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        // Destroy the enemies when they fall of
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
