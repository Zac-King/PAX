using UnityEngine;
using System.Collections;

public class Audio3D : MonoBehaviour
{
    /// <summary>
    /// Tran & Chui's test Audio script.
    /// </summary>

    
    public AudioSource audioSource;
    public AudioClip sound;
    public string audioEvent;
    public string argument;
    public bool sound3D;

    void Awake()
    {
        // audioSource gets everything AudioSource has.
        // Then the sound is assigned to audioSource.clip
        // argument is assigned to sound(AudioClip) to a string.
        // define newstring assigned to argument to replace the old string with another string, but my question, is how does it know the old string is (UnityEngine.AudioClip)
        // then argument is assigned to the newstring, which will produce audioClip name

        audioSource = GetComponent<AudioSource>();
        sound = audioSource.clip;
        argument = sound.ToString();
        string newstring = argument.Replace(" (UnityEngine.AudioClip)", "");
        argument = newstring;

        // For Triggers
        // For 3D audio, you must step in the trigger box for it to play 3D
        
        AudioManager.AddAudioToDictionary(argument, gameObject);
        AudioManager.AddListener(audioEvent, sound3D);
    }
}
