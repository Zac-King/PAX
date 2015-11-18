using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

static public class MenuSystem
{
	static Dictionary<string, List<GameObject>> menus = new Dictionary<string, List<GameObject>>();
	
	static public void AddPrefab(string argument, GameObject prefab)
	{
		//menus.Add(argument, prefab);
		if(menus.ContainsKey(argument) == false)
		{
			menus.Add(argument, new List<GameObject>());
		}
		menus [argument].Add (prefab);
	}
	
	static public void ListenerToTransition(string message)
	{
		Messenger.AddListener<string>(message, selfActivate);
	}
	
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
