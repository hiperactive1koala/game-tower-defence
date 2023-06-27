using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private Transform[] _waypoints;

    private void Awake()
    {
        _waypoints = new Transform[transform.childCount];
        for (int i = 0; i <_waypoints.Length; i++)
        {
            _waypoints[i] = transform.GetChild(i);
        }
    }

    public Transform[] GetWaypoints()
    {
        return _waypoints;
    }
}
