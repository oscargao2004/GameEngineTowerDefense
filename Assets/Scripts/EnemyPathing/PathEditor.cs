using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    [SerializeField] private float handleSize = 0.5f;
    private bool _editing;
    private Path _path;

    private void OnEnable()
    {
        _path = (Path)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Add Path Point"))
        {
            _path.CreatePathPoint();
        }
        
        EditorGUILayout.EndVertical();
    }

    private void OnSceneGUI()
    {
        for (int i = 0; i < _path.pointList.Count; i++)
        {
            Handles.color = Color.magenta;
            Handles.SphereHandleCap(-1, _path.pointList[i], Quaternion.identity, handleSize, EventType.Repaint);
        }
        
        
        
        
        
    }
}
