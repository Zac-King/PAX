using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Developed by: Quinton "Kiro" Baudoin
/// 
/// Purpose:
/// 	Creates an editor window to show the messages that have been listened for.
/// 
/// 
/// 
/// 
/// </summary>

public class MessengerWindow : EditorWindow 
{
	[MenuItem("Messenger/Messages")]
	static public void MakeWindow()
	{
		EditorWindow.GetWindow(typeof(MessengerWindow));
	}
	public void OnGUI()
	{
		string messages = "<<Empty>>";

		//EditorWindow.GetWindow(typeof(MessengerWindow));

		if(StaticMessengerGetter.MessengerListenerList().Count > 0)
		{
		foreach(string s in StaticMessengerGetter.MessengerListenerList())
		{
			//if(messages == "<<Empty>>")
			//		messages = s;

			//else 
					messages += Environment.NewLine + s;
		}
		}
	//	MonoBehaviour.print(messages);
		EditorGUILayout.LabelField("Listening For: ",EditorStyles.boldLabel);
		EditorGUILayout.LabelField(messages,EditorStyles.textArea);

		if(GUILayout.Button("Scan"))
			OnGUI();

	
	
	}

	void Rescan()
	{
		OnGUI();
	}
}
