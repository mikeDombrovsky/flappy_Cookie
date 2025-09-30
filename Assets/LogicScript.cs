using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private GameObject ScenesManager;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public GameObject pauseMenu; // Assign this in the inspector with your pause menu GameObject
    public bool isPauseActive = false;
    SoundMixerManager mixer;

    public AudioClip gameOverSound; // Assign this in the inspector with your game over sound clip
    public AudioClip scoreSound; // Assign this in the inspector with your score sound clip
    public AudioClip mainAudio; // Assign this in the inspector with your main audio clip

    

    private void Start()
    {
        ScenesManager = GameObject.Find("ScenesManager");
        playerScore = PlayerPrefs.GetInt("playerScore", 0); // Load the score from PlayerPrefs, default to 0 if not found
        // Initialize the score text
        scoreText.text = playerScore.ToString();
        // find the pause menu
        pauseMenu = GameObject.Find("PauseMenuCanvas");
        if (pauseMenu == null)
        {
            Debug.LogError("Pause menu not found! Make sure it exists in the scene."); return;
        }
        pauseMenu.SetActive(false); // Ensure the pause menu is initially inactive

        mixer = FindFirstObjectByType<SoundMixerManager>();// Find the SoundMixerManager in the scene
        mixer.SetMusicVolume(0.2f); // Set initial music volume
        
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
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        PlayerPrefs.SetInt("playerScore", playerScore); // Save the score to PlayerPrefs
        scoreText.text = playerScore.ToString();
        SoundFXManager.Instance.PlaySoundFXClip(scoreSound, transform, 1f); // Play the score sound effect
        if (playerScore >= 5 && playerScore < 10 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            ScenesManager.GetComponent<SceneManagerScript>().LoadSceneByIndex(1);
        }
    }

    public void resetScore()
    {
        if (playerScore < 5)
        {
            playerScore = 0;
        }
        else if (playerScore >= 5 && playerScore < 10)
        {
            playerScore = 5;
        }

        scoreText.text = playerScore.ToString();
        PlayerPrefs.SetInt("playerScore", playerScore); // Save the score to PlayerPrefs
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        mixer.SetMusicVolume(0.2f); // Restore the music volume
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        mixer.SetMusicVolume(0.1f); // Lower the music volume
        Debug.Log("music_volume: " + mixer.GetMusicVolume()); // Log the current music volume
        resetScore();
        SoundFXManager.Instance.PlaySoundFXClip(gameOverSound, transform, 1f); // Play the game over sound effect
    }

    public void TogglePauseMenu()
    {
        if (pauseMenu != null)
        {
            isPauseActive = !isPauseActive; // Toggle the state
            pauseMenu.SetActive(isPauseActive); // Set the active state of the pause menu
            Time.timeScale = isPauseActive ? 0f : 1f; // Pause or resume the game
        }
    }

    public void quitGame()
    {
        resetScore();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#endif
    }
}
