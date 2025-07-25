using UnityEngine;

public class CoctailTriggerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Debug.Log("LogicScript found, player score is: " + logic.playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 3) { return; }
        logic.addScore(1); // Call the addScore method from TrackScoreScript when the trigger is entered
        Debug.Log("Trigger entered by: " + collision.gameObject.name);
        
    }
}
