using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource ambientAudioAS;
    public AudioClip backgroundSound;

	/// <summary>
	/// Chui and Tran's audio script. 
	/// Pass in any audio clip that will loop in the background.
	/// Will be used as prefab.
	/// </summary>

    void Awake()
    {
        ambientAudioAS = GetComponent<AudioSource>();
		if (ambientAudioAS == null)
			Debug.Log ("Need to add AudioSource");
        ambientAudioAS.clip = backgroundSound;
        ambientAudioAS.loop = true;
        ambientAudioAS.priority = 256;
        ambientAudioAS.volume = 0.1f;
        ambientAudioAS.Play();
    }
}
