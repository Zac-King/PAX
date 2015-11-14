using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour 
{
	public void GameOverButton()
	{
		gameObject.SetActive(false);
		GameStateManager.ToStart();
	}
}
