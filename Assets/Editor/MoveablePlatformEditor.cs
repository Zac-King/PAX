using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(MovablePlatform))]
public class MovablePlatformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MovablePlatform myScript = (MovablePlatform)target;
        if (GUILayout.Button("Add Path Node"))
        {
            myScript.AddPathNode();
        }
    }
}