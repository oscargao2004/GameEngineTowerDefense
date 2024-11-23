using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Path : MonoBehaviour
{
    public List<Vector3> pointList = new List<Vector3>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CreatePathPoint()
    {
        pointList.Add(Vector3.zero);
    }

    public Vector3 GetPointAtIndex()
    {
        return Vector3.zero;
    }
}
