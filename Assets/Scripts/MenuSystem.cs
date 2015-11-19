using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

static public class MenuSystem
{
	/// <summary>
	/// Key : argument
	/// Value : list of Gameobjects
	/// </summary>
	static Dictionary<string, List<GameObject>> menus = new Dictionary<string, List<GameObject>>();

	/// <summary>
	/// Add string and gameobject to dict.
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
	/// Add Listener
	/// </summary>
	/// <param name="message">Message.
	/// It will listen to the message that it is interested in.
	/// </param>
	static public void ListenerToTransition(string message)
	{
		Messenger.AddListener<string>(message, selfActivate);
	}

<<<<<<< HEAD
	/// <summary>
	/// SelfActiviate sets gameobjects to true(switch them on)
	/// </summary>
	/// <param name="argument">Argument.
	/// Key to get the gameobject of that key
	/// </param>
=======
>>>>>>> coringuyen/master
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
