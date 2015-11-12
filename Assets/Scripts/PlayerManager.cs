using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : Singleton<PlayerManager>
{

    public GameObject Player1
    {
        get;
        private set;
    }
    public GameObject Player2
    {
        get;
        private set;
    }

    public int PlayerCount
    {
        get { return players.Count; }

        set { PlayerCount = value; }
    }
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    protected override void Awake()
    {
        //players are initially 0
       // PlayerCount = 0;

        List<PlayerCharacterController> pcc = new List<PlayerCharacterController>(FindObjectsOfType<PlayerCharacterController>());

        foreach (PlayerCharacterController p in pcc)
        {
            players.Add(p.gameObject);
        }
        if (players[0] != null)
        {
            Player1 = players[0];
           // PlayerCount++;
        }

        if (players[1] != null)
        {
            Player2 = players[1];
            //PlayerCount++;
        }
    }
}
