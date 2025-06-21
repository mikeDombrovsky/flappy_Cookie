using UnityEngine;

public class BirdFlyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.name = "Bobby";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }
        
    }
}
