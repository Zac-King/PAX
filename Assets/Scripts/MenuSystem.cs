using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

static public class MenuSystem
{
	/// <summary>
	/// A Dictionary that contains a key string and a list of Gameobjects of values.
	/// </summary>
	static Dictionary<string, List<GameObject>> menus = new Dictionary<string, List<GameObject>>();

	/// <summary>
	/// AddPrefab takes in string argument and Gameobject prefab.
	/// First it checks if the dict menus, if it contains a argument key, if not,
	/// it will add an argument and a new list of Gameobjects.
	/// after that, it will add a gameobject to that argument.
	/// </summary>
	/// <param name="argument">Argument.
	/// string argument used for transition
	/// </param>
	/// <param name="prefab">Prefab.
	/// Gameobject to use with argument
	/// </param>
	static public void AddPrefab(string argument, GameObject prefab)
	{
		//menus.Add(argument, prefab);
		if(menus.ContainsKey(argument) == false)
		{
			menus.Add(argument, new List<GameObject>());
		}
		menus [argument].Add (prefab);
	}

	/// <summary>
	/// Listens for the transitions
	/// If it's interested in that message, it will selfActivate, itself and set that gameobject to True
	/// </summary>
	/// <param name="message">Message.
	/// string message, to listen to the message that it is interested in.
	/// </param>
	static public void ListenerToTransition(string message)
	{
		Messenger.AddListener<string>(message, selfActivate);
	}

	/// <summary>
	/// SelfActiviate sets gameobjects to true(switch them on)
	/// </summary>
	/// <param name="argument">Argument.
	/// string argument in menus dict. to check if it's in the dict and set the gameobjects to true.
	/// </param>
	static private void selfActivate(string argument)
	{
		if (menus.ContainsKey (argument)) 
		{ 
			foreach (GameObject obj in menus[argument])
			{
				obj.SetActive(true);
			}
		} 
		else
			Debug.Log (argument + " not found");
	}
}
