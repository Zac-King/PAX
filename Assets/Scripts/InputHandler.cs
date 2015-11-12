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
    /// <summary>
    /// All Possible controls tha the user can assign
    /// to a Joystick Controller to control the game
    /// </summary>
    private enum E_JOYSTICK
    {
        e_A,
        e_B,
        e_X,
        e_Y,
        e_RightBumper,
        e_LeftBumper,
        e_RightStick,
        e_LeftStick,
        e_StartButton,
        e_BackButton
    }

    /// <summary>
    /// All Possible controls tha the user can assign
    /// to a Keyboard to controls the game
    /// </summary>
    private enum E_KEYBOARD
    {
        e_A,
        e_C,
        e_D,
        e_E,
        e_F,
        e_G,
        e_Q,
        e_R,
        e_S,
        e_T,
        e_V,
        e_W,
        e_X,
        e_Y,
        e_Z,
        e_Space,
        e_Escape,
        e_LeftShift,
    }

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {

    }

    void OnDisable()
    {
    }

    void Update()
    {
        IdleTimer();
    }

    /// <summary>
    /// Keeps track of how long a player has been idle
    /// or has placed no inputs
    /// </summary>
    private void IdleTimer()
    {
        IdleTime += Time.deltaTime;
    }

    /// <summary>
    /// Checks to see what kind of controller the user is using
    /// possible control options are Keyboard or Joystick Controller
    /// CALLED from context menu
    /// </summary>
	[ContextMenu("Check Controls")]
    void CheckControlType()
    {
		int numJoysticks = 0;
        //get a list of the controllers hooked up
        List<string> joy = new List<string>(Input.GetJoystickNames());
        //check the size and if its not 0 then we have controllers
        if (joy.Count > 0)
        {
			foreach(string s in joy)
			{
				if(s.Contains("Controller"))
				{

				}
			}
		}
    }

    /// <summary>
    /// Sets defaults for the controls
    /// </summary>
    public void SetDefualts()
    {
        jAttack = E_JOYSTICK.e_B;
        jJump = E_JOYSTICK.e_A;
        jSpecial = E_JOYSTICK.e_X;
        jSprint = E_JOYSTICK.e_RightBumper;

        kAttack = E_KEYBOARD.e_Q;
        kJump = E_KEYBOARD.e_Space;
        kSpecial = E_KEYBOARD.e_E;
        kSprint = E_KEYBOARD.e_LeftShift;
    }

    /// <summary>
    /// All variables of the InputHandler class
    /// </summary>
#region Varaibles
    [Header("Joystick Controls")]
    [SerializeField]
    private E_JOYSTICK jAttack; //Control assigned to the attack action if using a joystick
    [SerializeField]
    private E_JOYSTICK jJump; //Control assigned to the Jump Action if using a joystick
    [SerializeField]
    private E_JOYSTICK jSpecial; //Control assigned to the Specail Action if using a joystick
    [SerializeField]
    private E_JOYSTICK jSprint; //Control assigned to the Sprint Action if using a joystick

    [Space(25)]
    [Header("Keyboard Controls")]
    [SerializeField]
    private E_KEYBOARD kAttack; //Control assigned to the attack action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kJump; //Control assigned to the Jump Action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kSpecial; //Control assigned to the Specail Action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kSprint; //Control assigned to the Sprint Action if using the Keyboard

    public bool keyboard; //A boolean to determine if the controls are configured for keyboard or Controler

    //Strings to store the axis the objects move on
    //Used primarily to clean up the code
    private string p1Vert;
    private string p1Horizon;
    private string p2Vert;
    private string p2Horizon;

    private List<string> Players = new List<string>(); //List of players

    public List<string> PlayerControls = new List<string>(); //Controls defined by player
    public List<string> DefinedControls = new List<string>(); //Assigns the controls to controls recognized by unity

    private List<string> P1Controls = new List<string>(); //List that stores all controls for player 1
    private List<string> P2Controls = new List<string>(); //List that stores all controls for player 2

    private float IdleTime; //Will be used to turn return to main menu if no input for a certain time.


    #endregion
}
