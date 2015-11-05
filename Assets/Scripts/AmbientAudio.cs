using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource ambientAudioAS;
    public AudioClip backgroundSound;

    void Awake()
    {
        ambientAudioAS = GetComponent<AudioSource>();
        ambientAudioAS.clip = backgroundSound;
        ambientAudioAS.loop = true;
        ambientAudioAS.priority = 256;
        ambientAudioAS.volume = 0.1f;
        ambientAudioAS.Play();
    }
}
