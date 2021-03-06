﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretCluster : MonoBehaviour
{

    [SerializeField]
    private List<TurretBase> bases;

    [SerializeField]
    private GameObject turretPrefab;

    private void Awake()
    {
        bases = new List<TurretBase>(GetComponentsInChildren<TurretBase>());
        GameObject turret = Instantiate(turretPrefab, Teleport(null).transform);
        turret.GetComponent<TurretTeleport>().Teleport();
    }

    public TurretBase Teleport(TurretBase currentBase)
    {
        if(bases != null)
        {
            List<TurretBase> basesWithoutCurrent = bases.Where(val => currentBase != val).ToList();
            TurretBase newBase = basesWithoutCurrent[Random.Range(0, basesWithoutCurrent.Count)];
            return newBase;
        }
        return null;
    }
}
