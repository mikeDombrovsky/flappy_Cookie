using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 1f; // Speed at which the cloud moves
    public float destroyPositionX = -45f; // X position at which the cloud will be destroyed
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPositionX)
        {
            Debug.Log("Destroying enemy at position: " + transform.position.x);
            Destroy(gameObject); // Destroy the enemy game object
        }
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; // Move the enemy to the left
    }
}
