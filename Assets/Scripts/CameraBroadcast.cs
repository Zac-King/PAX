using UnityEngine;
using System.Collections;

public class CameraBroadcast : BroadcastOnTrigger
{
    protected override void OnTriggerEnter(Collider col)
    {
        Messenger.Broadcast<string, string>(message, col.name, this.name);
    }
}
