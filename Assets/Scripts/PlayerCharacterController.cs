using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
	public int PlayerNumber;

 	void Awake()
    {
		Messenger.AddListener<int>("NumOfJoysticks", AssignPlayerControls);
		Messenger.MarkAsPermanent("NumOfJoysticks");
    }
    // Use this for initialization
    void Start()
    {

    }


    void OnDisable()
    {
		Messenger.RemoveListener<int>("NumOfJoysticks", AssignPlayerControls);
    }

	/// <summary>
	/// Assigns the correct controls to the players depending on the 
	/// amount of joysticks connected to the controls.
	/// </summary>
	void AssignPlayerControls(int joysticks)
	{
		if(joysticks == 1)
		{
			if(PlayerNumber == 1)
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.KEYBOARD1;
			else if(PlayerNumber == 2)
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1;
		}
		else if(joysticks == 2)
		{
			if(PlayerNumber == 1)
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1;
			else if(PlayerNumber == 2)
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.CONTROLLER2;
		}
		else
		{
			if(PlayerNumber == 1)
			{
				GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.KEYBOARD1;
			}
			//If there are no controllers 
		}
	}
}