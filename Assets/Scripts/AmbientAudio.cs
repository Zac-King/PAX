using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource ambientAudioAS;
    public AudioClip backgroundSound;
    

    void Awake()
    {
        ambientAudioAS = GetComponent<AudioSource>();
        ambientAudioAS.clip = backgroundSound;
        ambientAudioAS.loop = true;
        ambientAudioAS.Play();
    }
}
