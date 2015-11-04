using UnityEngine;
using System.Collections;

public class AudioTrigger : BroadcastOnTrigger {
    public string argument;
    protected override void OnTriggerEnter(Collider col)
    {
        Messenger.Broadcast("playaudio", argument);
    }
}
