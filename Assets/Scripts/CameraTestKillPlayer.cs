using UnityEngine;
using System.Collections;

public class CameraTestKillPlayer : MonoBehaviour
{
    public string message;
    protected virtual void OnTriggerEnter(Collider col)
    {
        col.gameObject.SetActive(false);
        //col is the name of the object that enters the trigger
        Messenger.Broadcast<string>(message, col.tag);
    }
}
