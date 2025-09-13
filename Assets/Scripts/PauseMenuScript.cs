using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject allSoundSlider;
    public GameObject FXSlider;
    public GameObject musicSlider;
    SoundMixerManager soundMixerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundMixerManager = FindFirstObjectByType<SoundMixerManager>();// Find SoundMixerManager instance using FindFirstObjectByType
        allSoundSlider = GameObject.Find("MasterVolumelider");
        musicSlider = GameObject.Find("MusicVolumeSlider");
        FXSlider = GameObject.Find("SoundFXVolumeSlider");
         if (soundMixerManager == null || allSoundSlider == null || musicSlider == null || FXSlider == null)
         {
              Debug.LogError("One or more sliders not found! Make sure they exist in the scene.");
        }
        allSoundSlider.GetComponent<UnityEngine.UI.Slider>().value = soundMixerManager.GetMasterVolume();
        musicSlider.GetComponent<UnityEngine.UI.Slider>().value = soundMixerManager.GetMusicVolume();
        FXSlider.GetComponent<UnityEngine.UI.Slider>().value = soundMixerManager.GetSoundFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (allSoundSlider != null && soundMixerManager != null)
        {
            allSoundSlider.GetComponent<UnityEngine.UI.Slider>().value = soundMixerManager.GetMasterVolume();
            musicSlider.GetComponent<UnityEngine.UI.Slider>().value = soundMixerManager.GetMusicVolume();
            FXSlider.GetComponent<UnityEngine.UI.Slider>().value = soundMixerManager.GetSoundFXVolume();

        }
    }
}
