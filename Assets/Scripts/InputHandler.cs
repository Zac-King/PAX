using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

/// <summary>
/// Dylan Guidry
/// InputHandler.cs
/// 10/26/15
/// 
/// Handles all inputs by the user and if they are a input that is assigned to an action
/// it will publish it and what ever is listening for the event will perform the action 
/// </summary>
public class InputHandler : Singleton<InputHandler>
{
	public int TotalControllers;
	public int AvailableContollers;

    protected override void Awake()
    {
        base.Awake();
		//Braodcasted from the PlayerCharacterController
		Messenger.AddListener<string>("InputTypeChanged", AvailablePlayerControls);
    }

	void Start()
	{
		CheckControlType();
	}

	/// <summary>
	/// Checks what control types are availiable for the player to use
	/// Throws errors when they user tries to assign a control type that is not availiable
	/// 
	/// CALLED from PlayerCharacterController
	/// </summary>
	void AvailablePlayerControls(string change)
	{
		if(change == "KeyBoard" && AvailableContollers < TotalControllers)
		{
			//Adds a controller to the AvailiableControllers
			AvailableContollers++;
		}
		if(change == "Controller" && AvailableContollers != 0)
		{
			//Takes away a controller to the AvailiableControllers
			AvailableContollers--;
		}
		else if(change == "Controller" && AvailableContollers == 0)
		{
			//Throws an error if there are no available controllers and 
			//A player tries to assign a controler to a player object
			Debug.LogError("No Controllers Available");
			Debug.Break();
		}
	}
	
    /// <summary>
    /// Checks to see what kind of controller the user is using
    /// possible control options are Keyboard or Joystick Controller
    /// CALLED from Start()
    /// </summary>
    void CheckControlType()
    {
        //get a list of the controllers hooked up
        List<string> joy = new List<string>(Input.GetJoystickNames());
        //check the size and if its not 0 then we have controllers
        if (joy.Count > 0)
        {
			foreach(string s in joy)
			{
				if(s.Contains("Controller"))
				{
					TotalControllers++;
				}
			}
		}
		AvailableContollers = TotalControllers;
    }
}
