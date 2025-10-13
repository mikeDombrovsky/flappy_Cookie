using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pauseMenu; // Assign this in the inspector with your pause menu GameObject
    public bool isPauseActive = false;

    SoundMixerManager mixer;


    public AudioClip mainAudio; // Assign this in the inspector with your main audio clip
    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenuCanvas");// find the pause menu
        if (pauseMenu == null)
        {
            Debug.LogError("Pause menu not found! Make sure it exists in the scene."); return;
        }
        pauseMenu.SetActive(false); // Ensure the pause menu is initially inactive

        mixer = FindFirstObjectByType<SoundMixerManager>();// Find the SoundMixerManager in the scene
        mixer.SetMusicVolume(0.2f); // Set initial music volume
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu != null)
            {
                TogglePauseMenu();
            }
        }
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

    public void restartGame()
    {
        PlayerPrefs.SetInt("playerScore", 0); // Save the score to PlayerPrefs
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#endif
    }
}
