using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InputHandler))]
public class InputHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InputHandler InputScript = (InputHandler)target;

        if (GUILayout.Button("Reset Defaults"))
        {
            InputScript.SetDefualts();
        }
    }
}
