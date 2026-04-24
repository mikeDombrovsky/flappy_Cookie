using System;
using UnityEngine;

public class BirdFlyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 6;
    public LogicScript logic;

    int destroyPositionX = -45;
    int destroyPositionX2 = 45;
    int destroyPositionY = -45;
    int destroyPositionY2 = 45;
    public bool isBirdAlive = true; // Flag to check if the bird is active
    private int playerLives; // Variable to store the player's lives

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();  
        playerLives = PlayerPrefs.GetInt("playerLives", 3); // Load the player's lives from PlayerPrefs, default to 3 if not found
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        playerLives = PlayerPrefs.GetInt("playerLives", 3); // Update the player's lives from PlayerPrefs each frame

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isBirdAlive) return; // If the bird is already not alive, do nothing
        Debug.Log("playerLives: " + playerLives);
        if (playerLives > 0)
        {
            logic.loseLife(); // Call the loseLife method from LogicScript when a collision occurs
        }
        else
        {
            StopGame(); // Call the method to handle game over on collision
        }
    }

    private void StopGame()
    {
        logic.gameOver(); // Call the gameOver method from LogicScript when a collision occurs
        isBirdAlive = false; // Set the bird as not alive
    }

    private void FixedUpdate()
    {
        // Check if the bird's position is out of bounds
        if (transform.position.x < destroyPositionX || transform.position.x > destroyPositionX2 ||
            transform.position.y < destroyPositionY || transform.position.y > destroyPositionY2)
        {
            Destroy(gameObject); // Destroy the bird game object
            if (isBirdAlive)
            {
                StopGame(); // Call the method to handle game over 
            }
                
        }
    }
}
