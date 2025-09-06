using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Reference to the AudioMixer asset

    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("masterVolume", level);
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20); // Convert linear volume to logarithmic scale
    }
    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
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
