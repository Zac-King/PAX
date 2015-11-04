using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource ambientAudioAS;
    public AudioClip backgroundSound;

    void Awake()
    {
        // Background AudioSource = GetComp AudioSource
        // AudioManager.audioSource = AudioSource backgroundAudioSource;
        // AudioManager.AmbientSound(AudioClip) audio clip that is passed in


        ambientAudioAS = GetComponent<AudioSource>();
        ambientAudioAS.clip = backgroundSound;
        ambientAudioAS.playOnAwake = true;
        ambientAudioAS.loop = true;
        ambientAudioAS.priority = 256;
        ambientAudioAS.volume = 0.1f;
        ambientAudioAS.Play();

    }

}
