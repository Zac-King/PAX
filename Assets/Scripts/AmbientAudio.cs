using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource ambientAudioAS;
    public AudioClip backgroundSound;
    //public AudioClip backgroundSound2;

    void Awake()
    {
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
    }

    public void ChangeAmbientAudio()
    {

    }
}
