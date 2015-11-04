using UnityEngine;
using System.Collections;

public class BroadcastRaw : MonoBehaviour {
    public string message;
    void Start()
    {
        Messenger.Broadcast(message, gameObject.name);
    }
}
