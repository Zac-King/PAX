using UnityEngine;
using System.Collections;

public class Audio3D : MonoBehaviour
{
    /// <summary>
    /// Tran & Chui 3D Audio script.
    /// </summary>

    
    public AudioSource audioSource;
    public AudioClip sound;
    public string audioEvent;
    public string argument;
    public bool sound3D;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sound = audioSource.clip;
        argument = sound.ToString();
        string newstring = argument.Replace(" (UnityEngine.AudioClip)", "");
        argument = newstring;

        AudioManager.AddAudioToDictionary(argument, gameObject);
        AudioManager.AddListener(audioEvent, sound3D);
    }
}
