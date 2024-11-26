using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour
{
    private WaypointCreatorWrapper _wpCreator;
    private float t;
    private Enemy _enemy;
    private IntPtr _currentWaypoint;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        if (_wpCreator == null)
            _wpCreator = GetComponentInParent<WaypointCreatorWrapper>();
    }

    private void Start()
    {
        //_currentWaypoint = _wpCreator.GetPointAt(0);
        StartCoroutine(GoToNextWaypoint());
    }
    /*IEnumerator GoToNextWaypoint()
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
    }*/

    IEnumerator GoToNextWaypoint()
    {
        Vector3 previousWaypoint = transform.position;
        IntPtr nextWaypoint = _wpCreator.GetNextPoint(_currentWaypoint);
        for (int i = 0; i < _wpCreator.GetPointCount(); i++)
        {
            while (t < 1)
            {
                t += Time.deltaTime/Vector3.Distance(previousWaypoint, _wpCreator.GetPointLocation(nextWaypoint));
                transform.position = Vector3.Lerp(previousWaypoint, _wpCreator.GetPointLocation(nextWaypoint), t);

                yield return new WaitForEndOfFrame();
            }

            previousWaypoint = _wpCreator.GetPointLocation(nextWaypoint);
            if (i+1 < _wpCreator.GetPointCount())
                nextWaypoint = _wpCreator.GetPointAt(i+1);
            t = 0;
        }
    }
}

