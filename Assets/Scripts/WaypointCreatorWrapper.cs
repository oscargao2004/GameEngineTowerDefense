using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WaypointCreatorWrapper : MonoBehaviour
{
    [DllImport("WaypointCreator")] public static extern IntPtr CreateNewWaypointManager();
    [DllImport("WaypointCreator")] public static extern IntPtr AddWaypoint(int x, int y, int z, IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern void RemoveWaypoint(IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern IntPtr GetCurrentWaypoint(IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern IntPtr SetCurrentWaypoint(IntPtr waypoint, IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern IntPtr GetNextWaypoint(IntPtr waypointManager);
    [DllImport("WaypointCreator")] public static extern bool ComparePosition(int x, int y, int z, IntPtr waypoint);

    [DllImport("WaypointCreator")]
    public static extern int GetWaypointX(int x, int y, int z);

    private IntPtr _wpManager;
    void Start()
    {
        _wpManager = CreateNewWaypointManager();
        IntPtr wp = AddWaypoint(1, 2, 3, _wpManager);
        if (ComparePosition(1, 2, 3, wp))
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }
    }

    void Update()
    {
        
    }
}
