using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    public List<Vector3> path = new List<Vector3>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CreatePathPoint()
    {
        path.Add(Vector3.zero);
    }
}
