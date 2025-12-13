using UnityEngine;

public class SawMoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Speed at which the saw moves
    public float destroyPositionX = -50f; // X position at which the saw will be destroyed
    
    [Header("Movement Settings")]
    public float circularRadius = 0.01f;    // How big the circle is
    public float circularSpeed = 3f;     // How fast it rotates

    [Header("Saw Rotation")]
    public float rotationSpeed = 360f; // Degrees per second
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPositionX)
        {
            Debug.Log("Destroying saw at position: " + transform.position.x);
            Destroy(gameObject); // Destroy the saw game object
        }
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; // Move the saw to the left
        // Calculate circular motion offsets
        float circularX = Mathf.Sin(Time.time * circularSpeed) * circularRadius;
        float circularY = Mathf.Cos(Time.time * circularSpeed) * circularRadius;

        // Apply circular offset to current position
        Vector3 circularOffset = new Vector3(circularX, circularY, 0);
        transform.position = transform.position + circularOffset;

        // Rotate the saw around its center
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
