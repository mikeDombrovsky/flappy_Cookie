using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource soundFXObj; // Prefab for the AudioSource

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audio, Transform spawnTransform, float volume)
    {
        // spawn a new GameObject for the sound effect
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        // assign the audio clip to the AudioSource
        audioSource.clip = audio;
        //assign volume
        audioSource.volume = volume;
        //play the sound effect
        audioSource.Play();
        // get the length of the audio clip
        float clipLength = audio.length;
        // destroy the GameObject after the audio clip has finished playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
