using System;
using System.Collections;
using UnityEngine;

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
                Debug.Log("pathing");
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(previousWaypoint, nextWaypoint, t);

                yield return new WaitForEndOfFrame();
            }

            Debug.Log("waypoint reached");
            Debug.Log("heading to next waypoint");
            previousWaypoint = nextWaypoint;
            if (i+1 < _path.pointList.Count)
                nextWaypoint = _path.pointList[i+1];
            t = 0;
        }
    }
}
