using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _range = 15f;

    private void Start()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
