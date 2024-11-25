using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour
{
    private static Path _path;
    private bool _waypointReached = true;
    private float t;
    private Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        if (_path == null)
            _path = GetComponentInParent<Path>();
    }

    private void Start()
    {
        StartCoroutine(GoToNextWaypoint());
    }
    IEnumerator GoToNextWaypoint()
    {
        Vector3 previousWaypoint = transform.position;
        Vector3 nextWaypoint = _path.pointList[0];
        for (int i = 0; i < _path.pointList.Count; i++)
        {
            while (t < 1)
            {
                t += Time.deltaTime/Vector3.Distance(previousWaypoint, nextWaypoint);
                transform.position = Vector3.Lerp(previousWaypoint, nextWaypoint, t);

                yield return new WaitForEndOfFrame();
            }

            previousWaypoint = nextWaypoint;
            if (i+1 < _path.pointList.Count)
                nextWaypoint = _path.pointList[i+1];
            t = 0;
        }
    }
}

