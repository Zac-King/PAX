using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
	bool KeyBoard;

	void ControlCheck(bool check)
	{
		KeyBoard = check;
	}

	void Awake ()
	{
		AddListeners ();
	}

	// Use this for initialization
	void Start ()
	{
		Messenger.Broadcast<string> ("Player", gameObject.name);
	}

	void AddListeners ()
	{
		Debug.Log ("adding listeners");
		Messenger.AddListener<bool>("Controller", ControlCheck);
		Messenger.AddListener<int>(gameObject.name, PlayerNum);
		Messenger.MarkAsPermanent(gameObject.name);
	}

	void OnDisable ()
	{
		Debug.Log ("removing listeners");
		Messenger.RemoveListener<int>(gameObject.name, PlayerNum);
		Messenger.RemoveListener<bool>("Controller", ControlCheck);
	}
		
	void PlayerNum(int num)
	{
		Debug.Log(KeyBoard);
		switch(num)
		{
		case 0:
			if(KeyBoard == true)
			{
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = 
					UnityChanControlScriptWithRigidBody.InputState.KEYBOARD1;
			}
			else
			{
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = 
					UnityChanControlScriptWithRigidBody.InputState.PLAYER1;
			}
			break;
		case 1:
			GetComponent<UnityChanControlScriptWithRigidBody>().inputType = 
				UnityChanControlScriptWithRigidBody.InputState.PLAYER2;
			break;
		default:
			break;
		}
	}
}