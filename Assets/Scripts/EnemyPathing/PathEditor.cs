using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaypointCreatorWrapper))]
public class WaypointCreatorEditor : Editor
{
    [SerializeField] private float handleSize = 0.5f;
    private bool _editing;
    private WaypointCreatorWrapper _wpCreator;

    private void OnEnable()
    {
        _wpCreator = (WaypointCreatorWrapper)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Add Path Point"))
        {
            IntPtr newPoint = _wpCreator.AddPoint(0,0,0);
            Debug.Log("Added point at "+ _wpCreator.GetPointLocation(newPoint));
        }
        
        EditorGUILayout.EndVertical();
    }

    private void OnSceneGUI()
    {
        for (int i = 0; i < _wpCreator.GetPointCount(); i++)
        {
            Handles.color = Color.magenta;
            Handles.SphereHandleCap(-1, _wpCreator.GetPointLocation(_wpCreator.GetPointAt(i)), Quaternion.identity, handleSize, EventType.Repaint);
        }
        
    }
}
