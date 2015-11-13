using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour
{
    public string listeningFor;
    string activator;
    bool locked = false;

    void Awake()
    {
        Messenger.AddListener<GameObject, string>(listeningFor, Activate);

        BoxCollider[] children = GetComponentsInParent<BoxCollider>();
        foreach (Collider c in children)
        {
            if (c.isTrigger == true)
            {
                activator = c.name;
                return;
            }
        }
    }

    void Activate(GameObject o,string broadcaster)
    {
        if(o.tag == "Player" && locked == false && broadcaster == activator)
        {
            transform.position += new Vector3(0, 5, 0);
            locked = true;
        }
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<GameObject, string>(listeningFor, Activate);
    }
}
