using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmbientAudio : MonoBehaviour
{
    
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
    }

}
