using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmbientAudio : MonoBehaviour
{
<<<<<<< HEAD
    
    public AudioSource ambientAudioAS;
    public AudioClip backgroundSound;
    public string argument;
    public string ambientEvent;

    void Awake()
    { 
        ambientAudioAS.Play();
        AudioManager.AmbientAS = ambientAudioAS;
        AudioManager.AddAudioToDictionary(argument, gameObject);
        AudioManager.AddAmbientAudio(argument, backgroundSound);
        AudioManager.AddAmbientListener(ambientEvent);
=======
    public AudioSource backgroundAudioSource;
    public AudioClip backgroundAudioClip;

    void Awake()
    {
        // Background AudioSource = GetComp AudioSource
        // AudioManager.audioSource = AudioSource backgroundAudioSource;
        // AudioManager.AmbientSound(AudioClip) audio clip that is passed in
        backgroundAudioSource = GetComponent<AudioSource>();
        AudioManager.audioSource = backgroundAudioSource;
        AudioManager.AmbientSound(backgroundAudioClip);
>>>>>>> chui/master
    }
}
