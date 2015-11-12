using UnityEngine;
using System.Collections;

public class SetPlayerPosition : MonoBehaviour
{
    public string listeningFor;

    void Awake()
    {
        Messenger.AddListener<GameObject, string>(listeningFor, SetPlayerPos);
    }

    void SetPlayerPos(GameObject o, string s)
    {
        var players = FindObjectsOfType<PlayerCharacterController>();
        
        Debug.Log("player: " + (players.Length - 1));
        Debug.Log("player: " + players.Length);

        if (players.Length == 2)
        {
            if (Physics.Linecast(players[players.Length - 1].transform.position,
                players[players.Length].transform.position))
            {
                if (gameObject == players[players.Length].gameObject)
                {
                    players[players.Length - 1].transform.position = transform.position;
                }
                else
                {
                    players[players.Length].transform.position = transform.position;
                }
            }
        }

    }

    void OnDestroy()
    {
        Messenger.RemoveListener<GameObject, string>(listeningFor, SetPlayerPos);
    }
}
