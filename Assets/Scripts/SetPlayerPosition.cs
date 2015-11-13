using UnityEngine;
using System.Collections.Generic;

public class SetPlayerPosition : MonoBehaviour
{
    public string listeningFor;
    public float maxDistance;
    string activator;
    List<Transform> players = new List<Transform>();

    void Awake()
    {
        Messenger.AddListener<GameObject, string>(listeningFor, SetPlayerPos);

        //keep track of players
        var playerTemp = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < playerTemp.Length; ++i)
            players.Add(playerTemp[i].transform);

        //if hierarchy has multiple colliders, use the one that's a trigger
        BoxCollider[] children = GetComponentsInParent<BoxCollider>();
        foreach (Collider c in children)
        {
            if (c.isTrigger == true)
            {
                activator = c.name;
                return;
            }
        }

        //Debug.Log("players[0] == " + players[0]);
        //Debug.Log("players[1] == " + players[1]);

    }

    void SetPlayerPos(GameObject o, string broadcaster)
    {
        if (players.Count == 2 && o.tag == "Player" && broadcaster == activator)
        {
            //if (Physics.Linecast(players[0].position, players[1].position) || 
            //    Vector3.Distance(players[0].position, 
            //    players[1].position) >= maxDistance)
            //{
            //if gameObject that triggered the event is player1, move player2
            if (o == players[0].gameObject)
            {
                players[1].position = transform.position;
            }
            else
            {
                players[0].position = transform.position;
            }
            //}
        }

    }

    void OnDestroy()
    {
        Messenger.RemoveListener<GameObject, string>(listeningFor, SetPlayerPos);
    }
}
