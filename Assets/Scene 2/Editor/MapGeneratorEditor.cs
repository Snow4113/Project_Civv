using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGenerator = (MapGenerator)target;

        if (mapGenerator.autoUpdate)
        {
            mapGenerator.DrawMapInEditor();
        }

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            mapGenerator.DrawMapInEditor();
        }
    }
}
