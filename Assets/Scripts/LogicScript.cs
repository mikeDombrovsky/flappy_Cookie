using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private GameObject ScenesManager;
    public int playerScore;
    public int playerLives;
    public Text scoreText;
    public Text levelText;
    public GameObject gameOverScreen;

    public GameObject pauseMenu; // Assign this in the inspector with your pause menu GameObject
    public bool isPauseActive = false;
    SoundMixerManager mixer;

    public AudioClip gameOverSound; // Assign this in the inspector with your game over sound clip
    public AudioClip scoreSound; // Assign this in the inspector with your score sound clip
    public AudioClip mainAudio; // Assign this in the inspector with your main audio clip
    public AudioClip lostLifeAudio; // Assign this in the inspector with your lost life sound clip



    private void Start() 
    {
        ScenesManager = GameObject.Find("ScenesManager");
        playerScore = PlayerPrefs.GetInt("playerScore", 0); // Load the score from PlayerPrefs, default to 0 if not found
        playerLives = PlayerPrefs.GetInt("playerLives", 3); // Load the lives from PlayerPrefs, default to 3 if not found

        Debug.Log("initial playerLives: " + playerLives);

        scoreText.text = playerScore.ToString();// Initialize the score text
        levelText.text = "LVL:" + (SceneManager.GetActiveScene().buildIndex + 1);// Initialize the level text
        pauseMenu = GameObject.Find("PauseMenuCanvas");// find the pause menu
        if (pauseMenu == null)
        {
            Debug.LogError("Pause menu not found! Make sure it exists in the scene."); return;
        }
        pauseMenu.SetActive(false); // Ensure the pause menu is initially inactive

        // Ensure mixer is assigned (either set in inspector or found at runtime)
        if (mixer == null)
        {
            mixer = FindFirstObjectByType<SoundMixerManager>();
            if (mixer == null)
            {
                Debug.LogWarning("SoundMixerManager not found in scene. Volume controls will be skipped.");
            }
        }
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
        if(scoreToAdd <= 0)
        {
            Debug.LogWarning("Score to add must be greater than zero.");
            return;
        }
        playerScore += scoreToAdd;
        PlayerPrefs.SetInt("playerScore", playerScore); // Save the score to PlayerPrefs
        scoreText.text = playerScore.ToString();
        SoundFXManager.Instance.PlaySoundFXClip(scoreSound, transform, 1f); // Play the score sound effect

        if (playerScore >= 5 && playerScore < 10 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            ScenesManager.GetComponent<SceneManagerScript>().LoadSceneByIndex(1);
        }
        else if (playerScore >= 10 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            ScenesManager.GetComponent<SceneManagerScript>().LoadSceneByIndex(2);
        }
        else if (playerScore >= 15 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            resetScore();
            ScenesManager.GetComponent<SceneManagerScript>().LoadSceneByIndex(3);
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
        }else if (playerScore >= 10 && playerScore < 15)
        {
            playerScore = 10;
        }else if (playerScore >= 15)
        {
            playerScore = 0;
        }

        scoreText.text = playerScore.ToString();
        levelText.text = "LVL:" + (SceneManager.GetActiveScene().buildIndex + 1);// Update the level text
        PlayerPrefs.SetInt("playerScore", playerScore); // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("playerLives", 3); // Save refreshed lives to PlayerPrefs
    }


    public void restartGame()
    {
        resetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        mixer.SetMusicVolume(PlayerPrefs.GetFloat("musicVolume", 0.2f)); // Reset music volume to saved level if exists
    }
    [ContextMenu("Lose Life")]
    public void loseLife()
    {   
        if(playerLives <= 0)
        {
            Debug.LogWarning("Player lives are already at zero. Cannot lose more lives.");
            return;
        }
        playerLives--;
        PlayerPrefs.SetInt("playerLives", playerLives); // Save the lives to PlayerPrefs
        SoundFXManager.Instance.PlaySoundFXClip(lostLifeAudio, transform, 1f); // Play the lost life sound effect
    }
    public async void gameOver()
    {
        gameOverScreen.SetActive(true);
        resetScore();
        float musicVoilume = mixer.GetMusicVolume();
        mixer.SetMusicVolume(0.1f); // Lower the music volume
        //Debug.Log("music_volume: " + mixer.GetMusicVolume()); // Log the current music volume
        SoundFXManager.Instance.PlaySoundFXClip(gameOverSound, transform, 1f); // Play game-over sound effect
        await System.Threading.Tasks.Task.Delay(3000); // Wait for 3 seconds
        mixer.SetMusicVolume(musicVoilume); // Restore the original music volume
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
