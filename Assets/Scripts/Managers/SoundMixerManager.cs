using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Reference to the AudioMixer asset

    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("masterVolume", level);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20); // Convert linear volume to logarithmic scale
    }
    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
    }
}
