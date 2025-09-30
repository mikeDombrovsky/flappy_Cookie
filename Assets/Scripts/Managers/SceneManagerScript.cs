using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        if(string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is null or empty.");
            return;
        }
        if(!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError("Scene not found: " + sceneName);
            return;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {   
        if(sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Scene index out of range: " + sceneIndex);
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
