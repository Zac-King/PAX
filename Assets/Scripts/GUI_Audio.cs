using UnityEngine;
using System.Collections;

public class GUI_Audio : MonoBehaviour 
{
	/// <summary>
	/// Chui And Tran's script.
	/// This script will play a sound when you click on a GUI button
	/// </summary>

	AudioSource guiAudio;
	public AudioClip guiButton;

	void Awake()
	{
		guiAudio = GetComponent<AudioSource> ();
		if (guiAudio == null)
			Debug.Log ("Need to add AudioSource");
	}

	public void guiButtons()
	{
		playAudio(guiButton);
	}

	private void playAudio(AudioClip sound)
	{
		guiAudio.clip = sound;
		guiAudio.Play();
	}
}
