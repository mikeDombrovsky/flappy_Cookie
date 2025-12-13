using UnityEngine;

public class SawSpawnerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject saw;
    public float spawnRate = 5;
    private float timer = 0;
    public float hightOffset = 7f;
    void Start()
    {
        spawnSaw();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnSaw();
            timer = 0;
        }
    }

    void spawnSaw()
    {
        float lowestY = transform.position.y - hightOffset;
        float highestY = transform.position.y + hightOffset;
        Instantiate(saw, new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0), transform.rotation);
        Debug.Log("Spawned saw at: " + new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0));
    }
}
