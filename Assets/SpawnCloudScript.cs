using UnityEngine;

public class SpawnCloudScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cloud; // The cloud prefab to spawn
    public float spawnRate = 5f; // Rate at which clouds are spawned
    private float timer = 0f; // Timer to track spawn intervals
    public float heightOffset = 7f; // Vertical offset for cloud spawning
    public float depthOffset = 5f; // Depth offset for cloud spawning
    void Start()
    {
        spawnCloud(); // Initial cloud spawn
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime; // Increment the timer by the time since the last frame
        }
        else
        {
            spawnCloud(); // Spawn a new cloud when the timer reaches the spawn rate
            timer = 0f; // Reset the timer
        }
    }

    void spawnCloud()
    {
        float lowestY = transform.position.y - heightOffset; // Calculate the lowest Y position for spawning
        float highestY = transform.position.y + heightOffset; // Calculate the highest Y position for spawning

        float lowestZ = transform.position.z - depthOffset; // Calculate the lowest Z position for spawning
        float highestZ = transform.position.z + depthOffset; // Calculate the highest Z position for spawning
        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowestY, highestY), Random.Range(lowestZ, highestZ)), transform.rotation); // Instantiate the cloud at a random Y position within the range
    }       
}
