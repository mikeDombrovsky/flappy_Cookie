using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemy;
    public float spawnRate = 4;
    private float timer = 0;
    public float hightOffset = 7f;
    void Start()
    {
        spawnEnemy();
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
            spawnEnemy();
            timer = 0;
        }

    }

    void spawnEnemy()
    {
        float lowestY = transform.position.y - hightOffset;
        float highestY = transform.position.y + hightOffset;
        Instantiate(enemy, new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0), transform.rotation);
        Debug.Log("Spawned enemy at: " + new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0));
    }
}
