using UnityEngine;

public class LivesManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private int currentLives;
    void Start()
    {
        heart1 = GameObject.Find("heart-1");
        heart2 = GameObject.Find("heart-2");
        heart3 = GameObject.Find("heart-3");
        currentLives = PlayerPrefs.GetInt("playerLives", 3); // Load the current lives from PlayerPrefs, default to 3 if not found
    }

    // Update is called once per frame
    void Update()
    {
        currentLives = PlayerPrefs.GetInt("playerLives", 3); // Load the current lives from PlayerPrefs, default to 3 if not found
        if (currentLives > 0)
        {
            heart1.SetActive(currentLives >= 1); // Show heart 1 if lives are 1 or more
            heart2.SetActive(currentLives >= 2); // Show heart 2 if lives are 2 or more
            heart3.SetActive(currentLives >= 3); // Show heart 3 if lives are 3 or more

        }else if(currentLives <= 0)
        {
            heart1.SetActive(false); // Hide heart 1 if lives are 0 or less
            heart2.SetActive(false); // Hide heart 2 if lives are 0 or less
            heart3.SetActive(false); // Hide heart 3 if lives are 0 or less
        }   
    }
}
