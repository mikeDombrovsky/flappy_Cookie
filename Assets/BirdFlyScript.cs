using UnityEngine;

public class BirdFlyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 7;
    public LogicScript logic;
    public bool isBirdAlive = true; // Flag to check if the bird is active

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.name = "Bobby";
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
        logic.gameOver(); // Call the gameOver method from LogicScript when a collision occurs
        isBirdAlive = false; // Set the bird as not alive
    }
}
