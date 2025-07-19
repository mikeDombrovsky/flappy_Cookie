using UnityEngine;

public class SpawnCoctailScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject coctail;
    public float spawnRate = 3;
    private float timer = 0;
    public float hightOffset = 10f;
    void Start()
    {
        spawnCoctail();
    }

    // Update is called once per frame
    void Update()
    {   
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCoctail();
            timer = 0;
        }
           
    }

    void spawnCoctail()
    {
        float lowestY = transform.position.y - hightOffset;
        float highestY = transform.position.y + hightOffset;
        Instantiate(coctail, new Vector3(transform.position.x, Random.Range(lowestY, highestY),0), transform.rotation);
    }
}
