using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathCreator))]
public class PathCreatorEditor : Editor
{
    [SerializeField] private float handleSize = 0.5f;
    private bool _editing;
    private PathCreator _pathCreator;

    private void OnEnable()
    {
        _pathCreator = (PathCreator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Add Path Point"))
        {
            _pathCreator.CreatePathPoint();
        }
        
        EditorGUILayout.EndVertical();
    }

    private void OnSceneGUI()
    {
        for (int i = 0; i < _pathCreator.path.Count; i++)
        {
            Handles.color = Color.magenta;
            Handles.SphereHandleCap(-1, _pathCreator.path[i], Quaternion.identity, handleSize, EventType.Repaint);
        }
        
        
        
        
        
    }
}
