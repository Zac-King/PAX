using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
	public int PlayerNumber; //tells what numer the player is assigned. Set in the player manager

	UnityChanControlScriptWithRigidBody.InputState prev; //Creates a new variable of the InputState enum to check when 

	void Awake()
	{
		if(GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.DEFAULT)
		{
			Debug.LogError("A valid control scheme not set " + gameObject.name);
		}
	}

	void Update()
	{


		if(prev != GetComponent<UnityChanControlScriptWithRigidBody>().inputType)
		{
			if((GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1 && prev != UnityChanControlScriptWithRigidBody.InputState.CONTROLLER2) ||
			   (GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.CONTROLLER2 && prev != UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1))
			{
				Messenger.Broadcast<string>("InputTypeChanged", "Controller");
			}
			if(GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.KEYBOARD1)
			{
				Messenger.Broadcast<string>("InputTypeChanged", "KeyBoard");
			}
			prev = GetComponent<UnityChanControlScriptWithRigidBody>().inputType;
		}
	}
}