using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridSystem : MonoBehaviour
{
    private List<Vector3> _tiles = new List<Vector3>();
    
    [Header("Grid Properties")]
    [SerializeField] private int gridWidth = 5;
    [SerializeField] private int gridLength = 5;
    [SerializeField] private float centerPointRadius = 0.05f;
    
    [Header("Debug")] 
    [SerializeField] private Color gridColor;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CreateGrid()
    {
        _tiles = null;
        _tiles = new List<Vector3>();
        Vector3 startPos = transform.position - new Vector3((gridWidth / 2f) + 0.5f, 0, (gridLength / 2f) + 0.5f);

        for (int i = 1; i <= gridLength; i++)
        {
            for (int j = 1; j <= gridWidth; j++)
            {
                _tiles.Add(startPos + new Vector3(j, 0, i));
            }
        }
    }

    private void OnDrawGizmos()
    {
        gridColor.a = 1f;
        Gizmos.color = gridColor;

        Vector3 startPos = transform.position - new Vector3(gridWidth / 2f, 0, gridLength / 2f);

        for (int i = 0; i <= gridLength; i++)
        {
            Vector3 start = startPos + new Vector3(0, 0, i);
            Vector3 end = startPos + new Vector3(gridWidth, 0, i);
            Gizmos.DrawLine(start, end);
        }

        for (int i = 0; i <= gridWidth; i++)
        {
            Vector3 start = startPos + new Vector3(i, 0, 0);
            Vector3 end = startPos + new Vector3(i, 0, gridLength);
            Gizmos.DrawLine(start, end);
        }

        if (_tiles.Count > 0)
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                Gizmos.DrawSphere(_tiles[i], centerPointRadius);
            }
        }
    }
}
