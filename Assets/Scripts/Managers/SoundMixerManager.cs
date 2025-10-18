using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Reference to the AudioMixer asset

    GameObject MasterVolumeSlider;
    GameObject SoundFXVolumeSlider;
    GameObject MusicVolumeSlider;

    private void Start()
    {
        // Load saved volume levels from PlayerPrefs or set to default if not found
        float masterVolume = PlayerPrefs.GetFloat("masterVolume", 1f);
        float soundFXVolume = PlayerPrefs.GetFloat("soundFXVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.2f);
        SetMasterVolume(masterVolume);
        SetSoundFXVolume(soundFXVolume);
        SetMusicVolume(musicVolume);
    }

    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("masterVolume", level);
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20); // Convert linear volume to logarithmic scale
        PlayerPrefs.SetFloat("masterVolume", level); // Save the volume level to PlayerPrefs
    }
    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20);
        PlayerPrefs.SetFloat("soundFXVolume", level); // Save the volume level to PlayerPrefs
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
        PlayerPrefs.SetFloat("musicVolume", level); // Save the volume level to PlayerPrefs
    }

    public float GetMasterVolume()
    {
        audioMixer.GetFloat("masterVolume", out float level);
        return Mathf.Pow(10, level / 20); // Convert back to linear scale
    }
    public float GetSoundFXVolume()
    {
        audioMixer.GetFloat("soundFXVolume", out float level);
        return Mathf.Pow(10, level / 20);
    }
    public float GetMusicVolume()
    {
        audioMixer.GetFloat("musicVolume", out float level);
        return Mathf.Pow(10, level / 20);
    }
}
