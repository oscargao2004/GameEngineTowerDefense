using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridSystem))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridSystem gridSystem = (GridSystem)target;
        
        if (GUILayout.Button("Create Grid"))
        {
            gridSystem.CreateGrid();
        }
    }
    
}
