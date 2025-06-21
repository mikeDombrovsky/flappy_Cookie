using UnityEngine;

public class CoctailsMoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 7f; // Speed at which the cocktail moves
    public float destroyPositionX = -45f; // X position at which the cocktail will be destroyed
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the cocktail's position is less than the destroy position on the X axis
        if (transform.position.x < destroyPositionX)
        {   
            Debug.Log("Destroying cocktail at position: " + transform.position.x);
            Destroy(gameObject); // Destroy the cocktail game object
        }
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
