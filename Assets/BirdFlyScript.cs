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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopGame(); // Call the method to handle game over on collision
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
