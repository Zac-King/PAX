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

    void Awake()
    {
        Debug.Log("adding listeners");
        Messenger.AddListener<bool>("Controller", ControlCheck);
        //listens from input handler
        Messenger.AddListener<int>(gameObject.name, PlayerNum);
        Messenger.MarkAsPermanent(gameObject.name);

    }
    // Use this for initialization
    void Start()
    {
        Messenger.Broadcast<string>("Player", gameObject.name);
    }


    void OnDisable()
    {
        Debug.Log("removing listeners");
        Messenger.RemoveListener<int>(gameObject.name, PlayerNum);
        Messenger.RemoveListener<bool>("Controller", ControlCheck);
    }

    void PlayerNum(int num)
    {
        switch (num)
        {
            case 0:
                //this get sets from the inputhandler when it checks control type at CheckControl
                if (KeyBoard == true)
                    GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.KEYBOARD1;
                else
                    GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.CONTROLLER1;
                break;
            case 1:
                if(KeyBoard == true)
                    GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.KEYBOARD2;
                else
                    GetComponent<UnityChanControlScriptWithRigidBody>().inputType = UnityChanControlScriptWithRigidBody.InputState.CONTROLLER2;
                break;

            default:
                break;
        }
    }
}