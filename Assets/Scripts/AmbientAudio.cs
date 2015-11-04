using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioClip backgroundSound;

    void Awake()
    {
<<<<<<< HEAD
        // Background AudioSource = GetComp AudioSource
        // AudioManager.audioSource = AudioSource backgroundAudioSource;
        // AudioManager.AmbientSound(AudioClip) audio clip that is passed in
        backgroundAudioSource = GetComponent<AudioSource>();
        AudioManager.audioSource = backgroundAudioSource;
        AudioManager.AmbientSound(backgroundSound);
=======
<<<<<<< HEAD
        ambientAudioAS = GetComponent<AudioSource>();
        ambientAudioAS.clip = backgroundSound;
        ambientAudioAS.playOnAwake = true;
        ambientAudioAS.loop = true;
        ambientAudioAS.priority = 256;
        ambientAudioAS.volume = 0.1f;
        ambientAudioAS.Play();
=======
        backgroundAudioSource = GetComponent<AudioSource>();
        AudioManager.audioSource = backgroundAudioSource;
        AudioManager.AmbientSound(backgroundSound);
>>>>>>> matthew/master
>>>>>>> e5b34efe26fd2f02059a42bf4f0711c131a8ced6
    }

}
