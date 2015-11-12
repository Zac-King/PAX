using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StaticMessengerGetter
{

	static public List<string> MessengerListenerList()
	{
		List<string> Listener = new List<string>();
		if(Application.isPlaying)
		{
		
		foreach(KeyValuePair<string,Delegate> list in Messenger.eventTable)
		{
			//Listener.Add

			Listener.Add(list.Key);

		}
		}
		return Listener;
	}


}
