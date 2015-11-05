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
        Messenger.AddListener<string>("Player", NumberOfPlayers);
        Messenger.MarkAsPermanent("Player");
    }

    void Start()
    {
        //Adds all the controls to the list
        //They are modified in the SetControls Functions for each player
        CheckControlType();
    }

    void CustomContols()
    {
        PlayerControls.Clear();
        if (keyboard)
        {
            PlayerControls.Add(kAttack + ":Attack");
            PlayerControls.Add(kJump + ":Jump");
            PlayerControls.Add(kSpecial + ":Special");
            PlayerControls.Add(kSprint + ":Sprint");
        }
        else
        {
            PlayerControls.Add(jAttack + ":Attack");
            PlayerControls.Add(jJump + ":Jump");
            PlayerControls.Add(jSpecial + ":Special");
            PlayerControls.Add(jSprint + ":Sprint");
        }
        SetControls(numPlayers, keyboard);
    }

    void OnDisable()
    {
        Messenger.RemoveListener<string>("Player", NumberOfPlayers);
    }

    void Update()
    {
        IdleTimer();

        PlayerEvents();
    }

    /// <summary>
    /// Keeps track of how long a player has been idle
    /// or has placed no inputs
    /// </summary>
    private void IdleTimer()
    {
        IdleTime += Time.deltaTime;
        if (IdleTime > 20)
        {
            // Debug.Log("Thanks for playing");
            //Enable once we have an exit game
        }

        if (Input.anyKey || Input.GetAxis(p1Vert) != 0 || Input.GetAxis(p1Horizon) != 0 ||
            Input.GetAxis(p2Vert) != 0 || Input.GetAxis(p2Horizon) != 0)
        {
            IdleTime = 0;
        }
    }

    /// <summary>
    /// Broadcasts a message that an event trigger has happened
    /// in this case a button that has been assigned to a player event
    /// </summary>
    private void PlayerEvents()
    {
        Messenger.Broadcast<float, float>(Players[0] + ":", Input.GetAxis(p1Vert),
            Input.GetAxis(p1Horizon));
        if (numPlayers == 2)
        {
            Messenger.Broadcast<float, float>(Players[1] + ":", Input.GetAxis(p2Vert),
             Input.GetAxis(p2Horizon));
        }
        //Checks for inputs that are in the List of controls for player1
        foreach (string s in DefinedControls)
        {
            string[] temp = s.Split(':');
            if (Input.GetKeyDown(temp[0]))
            {
                if(temp[0].Contains("joystick 2"))
                {
                    Messenger.Broadcast(Players[1] + ":" + temp[1]);
                }
                else
                {
                    Messenger.Broadcast(Players[0] + ":" + temp[1]);
                }
            }
        }
    }

    /// <summary>
    /// Will be used to tell how many players are active in the game and will enable 
    /// the controls only necessary for that many players
    /// </summary>
    private void NumberOfPlayers(string pName)
    {
        if(!MaxPlayers)
        {
            Players.Add(pName);
            numPlayers += 1;
            if (Players.Count == 2)
            {
                MaxPlayers = true;
            }
        }
        CustomContols();
    }

    /// <summary>
    /// Sets the controls defined by the player to be 
    /// recognized by unity
    /// </summary>
    /// <param name="playerNum"></param>
    private void SetControls(int playerNum, bool keyboard)
    {
        for (int i = 0; i < PlayerControls.Capacity; i++)
        {

            string[] temp = PlayerControls[i].Split(':');
            string[] split = temp[0].Split('_');
            if (keyboard == false)
            {
                switch (split[1])
                {
                    case "A":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 0:" + temp[1]);
                            break;
                        }
                    case "B":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 1:" + temp[1]);
                            break;
                        }
                    case "X":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 2:" + temp[1]);
                            break;
                        }
                    case "Y":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 3:" + temp[1]);
                            break;
                        }
                    case "LeftBumper":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 4:" + temp[1]);
                            break;
                        }
                    case "RightBumper":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 5:" + temp[1]);
                            break;
                        }
                    case "BackButton":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 6:" + temp[1]);
                            break;
                        }
                    case "StartButton":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 7:" + temp[1]);
                            break;
                        }
                    case "LeftStick":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 8:" + temp[1]);
                            break;
                        }
                    case "RightStick":
                        {
                            DefinedControls.Add("joystick " + playerNum + " button 9:" + temp[1]);
                            break;
                        }
                    default:
                        break;
                }
            }
            else if (keyboard == true)
            {
                if(split[1] == "LeftShift")
                {
                    DefinedControls.Add("left shift:" + temp[1]);
                }
                else
                {
                    DefinedControls.Add(split[1].ToLower() + ":" + temp[1]);
                }

            }
        }
    }

    /// <summary>
    /// Checks to see what kind of controller the user is using
    /// possible control options are Keyboard or Joystick Controller
    /// </summary>
    void CheckControlType()
    {
        if (Input.GetJoystickNames()[0] != "")
        {
            keyboard = false;
            p1Horizon = "p1Horizontal";
            p1Vert = "p1Vertical";
            p2Horizon = "p2Horizontal";
            p2Vert = "p2Vertical";
        }
        else
        {
            keyboard = true;
            p1Vert = "p1KeyBoardVertical";
            p1Horizon = "p1KeyBoardHorizontal";
            p2Vert = "p2KeyBoardVertical";
            p2Horizon = "p2KeyBoardHorizontal";
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

    [Header("Keyboard Controls")]
    [Space(25)]
    [SerializeField]
    private E_KEYBOARD kAttack; //Control assigned to the attack action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kJump; //Control assigned to the Jump Action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kSpecial; //Control assigned to the Specail Action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kSprint; //Control assigned to the Sprint Action if using the Keyboard

    private bool keyboard; //A boolean to determine if the controls are configured for keyboard or Controler

    public int numPlayers; //Keeps track of number of players active in the game

    bool MaxPlayers; //If num players = 2 this is true

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
