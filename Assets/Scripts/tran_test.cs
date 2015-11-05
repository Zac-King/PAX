using UnityEngine;
using System.Collections;

public class tran_test : MonoBehaviour {

    public string AmbientEvent;
    public string argument;
	void OnTriggerEnter(Collider other)
    {
        Messenger.Broadcast<string>(AmbientEvent, argument);
    }
}
