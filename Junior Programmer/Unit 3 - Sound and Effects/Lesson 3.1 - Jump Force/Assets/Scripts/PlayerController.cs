using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //ForceMode.Impulse - Applies an instant force on the Object, taking mass into account.
            //This pushes the Object using the entire force in a single frame.
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // Get triggered Animator's paramater Jump_trig
            playerAnim.SetTrigger("Jump_trig");
            // When we jump stop dirt particle
            dirtParticle.Stop();
        }
    }
    // After jumping and returning to the ground, we set it to true with the collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // Play dirt particle when player on ground
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over !!!");
            // Acces to animator layers' conditions of death and set the values
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // Start the explosion particle
            explosionParticle.Play();
            // Stop the dirt particle
            dirtParticle.Stop();
        }
        
    }
}
