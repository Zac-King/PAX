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
        //e_R,
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

    }

    void Start()
    {
        //Adds all the controls to the list
        //They are modified in the SetControls Functions for each player
        CheckControlType();

        if (keyboard)
        {
            P1Controls.Add(kAttack + ":Attack");
            P1Controls.Add(kJump + ":Jump");
            P1Controls.Add(kSpecial + ":Special");
            P1Controls.Add(kSprint + ":Sprint");
        }
        else
        {
            P1Controls.Add(jAttack + ":Attack");
            P1Controls.Add(jJump + ":Jump");
            P1Controls.Add(jSpecial + ":Special");
            P1Controls.Add(jSprint + ":p1Sprint");

            P2Controls.Add(jAttack + ":Attack");
            P2Controls.Add(jJump + ":Jump");
            P2Controls.Add(jSpecial + ":Special");
            P2Controls.Add(jSprint + ":Sprint");
        }
        SetP1Controls();
        SetP2Controls();
    }


    void Update()
    {
        IdleTimer();

        if (numPlayers != 0)
        {
            P1Events();
            if (MaxPlayers)
            {
                P2Evnets();
            }
        }
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
    /// Contains all the Event Triggers for Player1
    /// This function is only called in while there is at least one player in the scene
    /// </summary>
    private void P1Events()
    {
        Messenger.Broadcast<float, float>(Players[0] + ":", Input.GetAxis(p1Vert),
            Input.GetAxis(p1Horizon));
        //Checks for inputs that are in the List of controls for player1
        foreach (string s in P1Controls)
        {
            string[] temp = s.Split(':');
            if (Input.GetKeyDown(temp[0]))
            {
                Messenger.Broadcast(Players[0] + ":" + temp[1]);
            }
        }
    }

    /// <summary>
    /// Contains all the Event Triggers for Player2
    /// This function is only called in while there is at least two players in the scene
    /// </summary>
    private void P2Evnets()
    {
        Messenger.Broadcast<float, float>(Players[1] + ":", Input.GetAxis(p2Vert),
            Input.GetAxis(p2Horizon));
        //Checks for inputs that are in the List of controls for player2
        foreach (string s in P2Controls)
        {
            string[] temp = s.Split(':');
            if (Input.GetKeyDown(temp[0]))
            {
                Messenger.Broadcast(Players[1] + ":" + temp[1]);
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
            if(Players.Count == 2)
            {
                MaxPlayers = true;
            }
        }
    }

    /// <summary>
    /// Sets the controls the user defines in to the list of controls for there selected character
    /// to utilize and react to when they are pressed
    /// </summary>
    private void SetP1Controls()
    {
        for (int i = 0; i < P1Controls.Capacity; i++)
        {
            string[] temp = P1Controls[i].Split(':');
            string[] split = temp[0].Split('_');
            {
                switch (split[1])
                {
                    case "A":
                        {
                            P1Controls[i] = "joystick 1 button 0:" + temp[1];
                            break;
                        }
                    case "B":
                        {
                            P1Controls[i] = "joystick 1 button 1:" + temp[1];
                            break;
                        }
                    case "X":
                        {
                            P1Controls[i] = "joystick 1 button 2:" + temp[1];
                            break;
                        }
                    case "Y":
                        {
                            P1Controls[i] = "joystick 1 button 3:" + temp[1];
                            break;
                        }
                    case "LeftBumper":
                        {
                            P1Controls[i] = "joystick 1 button 4:" + temp[1];
                            break;
                        }
                    case "RightBumper":
                        {
                            P1Controls[i] = "joystick 1 button 5:" + temp[1];
                            break;
                        }
                    case "BackButton":
                        {
                            P1Controls[i] = "joystick 1 button 6:" + temp[1];
                            break;
                        }
                    case "StartButton":
                        {
                            P1Controls[i] = "joystick 1 button 7:" + temp[1];
                            break;
                        }
                    case "LeftStick":
                        {
                            P1Controls[i] = "joystick 1 button 8:" + temp[1];
                            break;
                        }
                    case "RightStick":
                        {
                            P1Controls[i] = "joystick 1 button 9:" + temp[1];
                            break;
                        }
                }
            }

            if(keyboard)
            {
                if (split[1].ToLower() == "leftshift")
                {
                    P1Controls[i] = "left shift:" + temp[1];
                }
                else if (split[1].ToLower() == "rightshift")
                {
                    P1Controls[i] = "right shift:" + temp[1];
                }
                else
                {
                    P1Controls[i] = split[1].ToLower() + ":" + temp[1];
                }
            }
        }
    }

    /// <summary>
    /// Sets the controls the user defines in to the list of controls for there selected character
    /// to utilize and react to when they are pressed
    /// </summary>
    private void SetP2Controls()
    {
        //Checks the button the user assigns to the selected action and assigns it to the appropriate
        //string value for unity to recognize inputs of that type

        for (int i = 0; i < P2Controls.Capacity; i++)
        {
            string[] temp = P2Controls[i].Split(':');
            string[] split = temp[0].Split('_');
            switch (split[1])
            {
                case "A":
                    {
                        P2Controls[i] = "joystick 2 button 0:" + temp[1];
                        break;
                    }
                case "B":
                    {
                        P2Controls[i] = "joystick 2 button 1:" + temp[1];
                        break;
                    }
                case "X":
                    {
                        P2Controls[i] = "joystick 2 button 2:" + temp[1];
                        break;
                    }
                case "Y":
                    {
                        P2Controls[i] = "joystick 2 button 3:" + temp[1];
                        break;
                    }
                case "LeftBumper":
                    {
                        P2Controls[i] = "joystick 2 button 4:" + temp[1];
                        break;
                    }
                case "RightBumper":
                    {
                        P2Controls[i] = "joystick 2 button 5:" + temp[1];
                        break;
                    }
                case "BackButton":
                    {
                        P2Controls[i] = "joystick 2 button 6:" + temp[1];
                        break;
                    }
                case "StartButton":
                    {
                        P2Controls[i] = "joystick 2 button 7:" + temp[1];
                        break;
                    }
                case "LeftStick":
                    {
                        P2Controls[i] = "joystick 2 button 8:" + temp[1];
                        break;
                    }
                case "RightStick":
                    {
                        P2Controls[i] = "joystick 2 button 9:" + temp[1];
                        break;
                    }
                default:
                    {
                        break;
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

        string[] s = Input.GetJoystickNames();
        if (s[0] != "")
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
            p1Vert = "KeyBoardVertical";
            p1Horizon = "KeyBoardHorizontal";
            p2Horizon = "p1Horizontal";
            p2Vert = "p1Vertical";
        }



    }

    /// <summary>
    /// Sets defaults for the controls
    /// </summary>
    [ContextMenu("Set Defualts")]
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

    private bool keyboard; //A boolean to determine if the controls are configured for keyboard or Controler

    private int numPlayers; //Keeps track of number of players active in the game

    bool MaxPlayers; //If num players = 2 this is true

    //Strings to store the axis the objects move on
    //Used primarily to clean up the code
    private string p1Vert;
    private string p1Horizon;
    private string p2Vert;
    private string p2Horizon;

    private List<string> Players = new List<string>(); //List of players

    private List<string> P1Controls = new List<string>(); //List that stores all controls for player 1
    private List<string> P2Controls = new List<string>(); //List that stores all controls for player 2

    private float IdleTime; //Will be used to turn return to main menu if no input for a certain time.


#endregion
}
