using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour 
{

	public GameObject player1;
	public GameObject player2;
	public GameObject creditmenu;
	public GameObject ingame;
	public GameObject gameover;

	void Start () 
	{
		MenuSystem.AddPrefab ("start->play", player1);
		MenuSystem.AddPrefab ("start->play", player2);
		MenuSystem.AddPrefab ("start->end", creditmenu);
		MenuSystem.AddPrefab ("play->gameover", gameover);
		MenuSystem.AddPrefab ("pause->gameover", gameover);
		MenuSystem.AddPrefab ("play->pause", ingame);
		MenuSystem.ListenerToTransition ("gamestatechanged");
	}
}
