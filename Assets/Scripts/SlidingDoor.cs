using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour
{
    public string listeningFor;
    void Awake()
    {
        Messenger.AddListener<GameObject, string>(listeningFor, Activate);
    }

    void Activate(GameObject o,string s)
    {
        if(o.tag == "Player")
        {
            transform.position += new Vector3(0, 5, 0);
        }
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<GameObject, string>(listeningFor, Activate);
    }
}
