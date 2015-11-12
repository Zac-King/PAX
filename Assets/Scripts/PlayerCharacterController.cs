using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
	public int PlayerNumber; //tells what numer the player is assigned. Set in the player manager

	UnityChanControlScriptWithRigidBody.InputState prev; //Creates a new variable of the InputState enum to check when 

	/// <summary>
	/// Checks to see if a valid control scheme has been set.
	/// If one has not been set and is still at the default it will throw an error.
	/// </summary>
	void Awake()
	{
		if(GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.DEFAULT)
		{
			Debug.LogError("A valid control scheme not set " + gameObject.name);
			Debug.Break();
		}
	}

	/// <summary>
	/// Conditional checks for when the control scheme has been changed at runtime by user
	/// </summary>
	void Update()
	{
		if(prev != GetComponent<UnityChanControlScriptWithRigidBody>().inputType)
		{
			if((GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1 && prev != UnityChanControlScriptWithRigidBody.InputState.CONTROLLER2) ||
			   (GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.CONTROLLER2 && prev != UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1))
			{
				//Listened to by the InputHandler
				Messenger.Broadcast<string>("InputTypeChanged", "Controller");
			}
			if(GetComponent<UnityChanControlScriptWithRigidBody>().inputType == UnityChanControlScriptWithRigidBody.InputState.KEYBOARD1)
			{
				//Listened to by the InputHandler
				Messenger.Broadcast<string>("InputTypeChanged", "KeyBoard");
			}
			//Sets the current prev = the curretn inputType
			prev = GetComponent<UnityChanControlScriptWithRigidBody>().inputType;
		}
	}
}