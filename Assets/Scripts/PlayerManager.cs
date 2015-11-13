using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : Singleton<PlayerManager>
{
	/// <summary>
	/// Gets the player1.
	/// </summary>
	/// <value>The player1.</value>
    public GameObject Player1
    {
        get;
        private set;
    }

	/// <summary>
	/// Gets the player2.
	/// </summary>
	/// <value>The player2.</value>
    public GameObject Player2
    {
        get;
        private set;
    }

	//The total amount of players in the scene
    public int PlayerCount
    {
        get { return players.Count; }

        set { PlayerCount = value; }
    }

	/// <summary>
	/// List of GameObjects that store the data of Player Objects in the scene
	/// </summary>
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    protected override void Awake()
    {
		base.Awake();

		//Looks for all objects in the scene that are of type PlayerCharacterController and adds them a new list;
        List<PlayerCharacterController> pcc = new List<PlayerCharacterController>(FindObjectsOfType<PlayerCharacterController>());

		//Loops through the list pcc and adds them to the players list
        foreach (PlayerCharacterController p in pcc)
        {
            players.Add(p.gameObject);
        }

		//Assigns the players at certain index a player number and gives the
		//GameObjects Player1 and Player2 some data
        if (players[0] != null)
        {
            Player1 = players[0];
			Player1.GetComponent<PlayerCharacterController>().PlayerNumber = 1;
        }

		//Checks to see if the amount of elements in the array are greater than
		if(players.Count > 1)
        	if (players[1] != null)
        	{
            	Player2 = players[1];
				Player1.GetComponent<PlayerCharacterController>().PlayerNumber = 2;
        	}
    }




}
