using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour 
{
	public void resume()
	{
		gameObject.SetActive (false);
		GameStateManager.ToPlay ();
	}

	public void exitPause()
	{
		gameObject.SetActive (false);
		GameStateManager.ToGameover ();
	}
}
