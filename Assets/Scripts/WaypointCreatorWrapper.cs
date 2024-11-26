using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WaypointCreatorWrapper : MonoBehaviour
{
    [DllImport("WaypointCreator")] public static extern IntPtr CreateNewWaypointManager();
    [DllImport("WaypointCreator")] public static extern IntPtr AddWaypoint(float x, float y, float z, IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern void RemoveWaypoint(IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern IntPtr GetNextWaypoint(IntPtr waypoint);
    [DllImport("WaypointCreator")] public static extern bool ComparePosition(float x, float y, float z, IntPtr waypoint);
    [DllImport("WaypointCreator")] public static extern float GetWaypointX(IntPtr waypoint);
    [DllImport("WaypointCreator")] public static extern float GetWaypointY(IntPtr waypoint);
    [DllImport("WaypointCreator")] public static extern float GetWaypointZ(IntPtr waypoint);
    [DllImport("WaypointCreator")] public static extern IntPtr GetWaypointAtIndex(int index, IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern IntPtr GetFirstWaypoint(IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern IntPtr GetLastWaypoint(IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern int GetWaypointCount(IntPtr waypointManager);

    private IntPtr _instance;

    public WaypointCreatorWrapper()
    {
        _instance = CreateNewWaypointManager();
    }

    public IntPtr AddPoint(float x, float y, float z)
    {
        IntPtr newPoint = AddWaypoint(x, y, z, _instance);
        return newPoint;
    }
    public void AddPoint(Vector3 vec)
    {
        AddWaypoint(vec.x, vec.y, vec.z, _instance);
    }

    public void RemovePoint()
    {
        RemoveWaypoint(_instance);
    }

    public Vector3 GetPointLocation(IntPtr waypoint)
    {
        return new Vector3(GetWaypointX(waypoint), GetWaypointY(waypoint), GetWaypointZ(waypoint));
    }

    public IntPtr GetPointAt(int index)
    {
        return GetWaypointAtIndex(index, _instance);
    }

    public IntPtr GetFirst()
    {
        return GetFirstWaypoint(_instance);
    }

    public IntPtr GetLast()
    {
        return GetLastWaypoint(_instance);
    }

    public IntPtr GetNextPoint(IntPtr waypoint)
    {
        return GetNextWaypoint(waypoint);
    }

    public bool ComparePos(Vector3 position, IntPtr waypoint)
    {
        return ComparePosition(position.x, position.y, position.z, waypoint);
    }

    public int GetPointCount()
    {
        return GetWaypointCount(_instance);
    }
    
    
    
    
    
}
