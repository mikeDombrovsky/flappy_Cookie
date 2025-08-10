using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioClip gameOverSound; // Assign this in the inspector with your game over sound clip
    public AudioClip scoreSound; // Assign this in the inspector with your score sound clip
    public AudioClip mainAudio; // Assign this in the inspector with your main audio clip

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        SoundFXManager.Instance.PlaySoundFXClip(scoreSound, transform, 1f); // Play the score sound effect
    }

    private void Start()
    {
        // Initialize the score text
        scoreText.text = playerScore.ToString();
        
        // Play the main audio at the start of the game
        //SoundFXManager.Instance.PlaySoundFXClip(mainAudio, transform, 0.5f);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        SoundFXManager.Instance.PlaySoundFXClip(gameOverSound, transform, 0.5f); // Play the game over sound effect
    }

    public void quitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
        #endif
    }   
}
