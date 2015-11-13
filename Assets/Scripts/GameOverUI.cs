using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour 
{
	void Start()
	{
		MenuSystem.AddPrefab ("play->gameover", gameObject);
		MenuSystem.AddPrefab ("pause->gameover", gameObject);
		MenuSystem.ListenerToTransition ("transition");
	}

	public void GameOverButton()
	{
		gameObject.SetActive(false);
		GameStateManager.ToStart();
	}
}
