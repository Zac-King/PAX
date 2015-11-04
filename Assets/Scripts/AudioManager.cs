using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tran and Paul audio file!
/// </summary>
static public class AudioManager
{
    /// <summary>
    /// Audio Source to play audio
    /// </summary>
    static public AudioSource audioSource;

    /// <summary>
    /// Key : string arg
    /// Value : AudioClip
    /// play audio depend on the string arg
    /// </summary>
    static Dictionary<string, GameObject> audioTable = new Dictionary<string, GameObject>();

    /// <summary>
    /// Add AudioClip with string argument to Dictionary
    /// </summary>
    /// <param name ="argument">
    /// Argument that audio need to play to
    /// </param>
    /// <param name ="audioclip">
    /// Audioclip that plays with the assign argument
    /// </param>
    static public void AddAudioToDictionary(string argument, GameObject audioclip)
    {
        if (audioTable.ContainsKey(argument))
        {
            Debug.Log(argument.ToString() + "This message already exist");
        }
        else
            audioTable.Add(argument, audioclip);
    }

    /// <summary>
    /// Subscribing to broadcast message that audio will listen to and play 3D audio
    /// </summary>
    /// <param name="messageBroadcast">
    /// The message that is interested in.
<<<<<<< HEAD:Assets/Scripts/Audio.cs
    /// </param>
    /// <param name="threeD">
    /// Set Audio 3D.
    /// </param>
    static public void AudioListener(string messageBroadcast, bool threeD)
=======
    ///</param>
    static public void AddListener(string messageBroadcast, bool threeD)
>>>>>>> matthew/master:Assets/Scripts/AudioManager.cs
    {
        if(threeD)
        {
            Messenger.AddListener<string>(messageBroadcast, play3DAudio);
        }
        else
            Messenger.AddListener<string>(messageBroadcast, play2DAudio);
    }

    /// <summary>
    /// So all audioClips start off 2D
    /// This function turns 2D Audio Clips into 3D
    /// </summary>
    /// <param name="audioClip">
    /// The audio that is passed in, will turn into 3D audio
    /// </param>
    static private void play3DAudio(string argument)
    {
        GameObject aud = audioTable[argument];
        AudioSource asrc = aud.GetComponent<AudioSource>();
        // Setting spatialBlend 0 is 2D & 1 is 3D;
        asrc.clip = audioTable[argument].GetComponent<AudioSource>().clip ;
        asrc.spatialBlend = 1;
        asrc.minDistance = 1.0f;
        asrc.maxDistance = 5.0f;
        asrc.Play();
    }

    /// <summary>
    /// Play the audio
    /// </summary>
    /// <param name="argument">
    /// Argument that audio needs to play to. :3
    /// </param>
    static private void play2DAudio(string argument)
    {
        GameObject aud = audioTable[argument];
        AudioSource asrc = aud.GetComponent<AudioSource>();
       
        asrc.Play();
    }
<<<<<<< HEAD:Assets/Scripts/Audio.cs
=======

    static public void AmbientSound(AudioClip sound)
    {
        //Ambient = surround sound (3D sound)
        audioSource.clip = sound;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.priority = 256;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }
>>>>>>> matthew/master:Assets/Scripts/AudioManager.cs
}
