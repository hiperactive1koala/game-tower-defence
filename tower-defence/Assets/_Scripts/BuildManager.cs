using System;
using UnityEngine;
using Utilities;

public class BuildManager : Singleton<BuildManager>
{
    private GameObject _turretToBuild;

    [SerializeField] private GameObject _standardTurretPrefab;

    private void Start()
    {
        _turretToBuild = _standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
}
