using UnityEngine;
using System.Collections;

public class AudioTrigger : BroadcastOnTrigger
{
    [SerializeField]
	private AudioClip soundClip;

	/// <summary>
	/// Tran and Chui's Audio Trigger.
	/// 
	/// Pass in a soundClip so it will play the audio clip that assign to object.
	/// </summary>
	/// <param name="col">Col.</param>

    protected override void OnTriggerEnter(Collider col)
    {
        Messenger.Broadcast("playaudio", soundClip.name);
    }
}
