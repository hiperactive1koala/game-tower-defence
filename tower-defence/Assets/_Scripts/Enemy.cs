using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private int _wavePointIndex= 0;
    private Transform[] _waypoints;

    private void Start()
    {
        var dots = FindObjectOfType<Waypoints>();
        _waypoints = dots.GetWaypoints();
        _target = _waypoints[0];
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * (_speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, _target.position) < 0.3f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= _waypoints.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        _wavePointIndex++;
        _target = _waypoints[_wavePointIndex];
    }

    public void SetDetails(Transform[] waypointArray, float speed = 10f )
    {
        _waypoints = waypointArray;
        _speed = speed;
    }
}
