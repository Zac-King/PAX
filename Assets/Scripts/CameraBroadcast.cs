using UnityEngine;
using System.Collections;

public class CameraBroadcast : BroadcastOnTrigger
{    
    protected override void OnTriggerEnter(Collider col)
    {
        Messenger.Broadcast<GameObject, string>(message, col.gameObject, this.name);
    }
}
