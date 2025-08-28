using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
<<<<<<< Updated upstream
=======
        SoundFXManager.Instance.PlaySoundFXClip(scoreSound, transform, 1f); // Play the score sound effect
    }

    private void Start()
    {
        // Initialize the score text
        scoreText.text = playerScore.ToString();
        // find the pause menu
        pauseMenu = GameObject.Find("PauseMenuCanvas");
        if (pauseMenu == null)
        {
            Debug.LogError("Pause menu not found! Make sure it exists in the scene."); return;
        }
        pauseMenu.SetActive(false); // Ensure the pause menu is initially inactive
    }
    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu != null)
            {
                TogglePauseMenu();
            }
        }

>>>>>>> Stashed changes
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
<<<<<<< Updated upstream
=======
        SoundFXManager.Instance.PlaySoundFXClip(gameOverSound, transform, 0.5f); // Play the game over sound effect
    }

    public void TogglePauseMenu()
    {
        if (pauseMenu != null)
        {
            isPauseActive = !isPauseActive; // Toggle the state
            pauseMenu.SetActive(isPauseActive); // Set the active state of the pause menu
            Time.timeScale = isPauseActive ? 0f : 1f; // Pause or resume the game
        }
>>>>>>> Stashed changes
    }

    public void quitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
        #endif
    }   
}
