using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTeleport : MonoBehaviour
{
    [SerializeField]
    private TurretBase parent;

    [SerializeField]
    private TurretCluster cluster;

    [SerializeField]
    private float minTimer = 1;

    [SerializeField]
    private float maxTimer = 3;

    private float currentTime;

    private void Awake()
    {
        parent = GetComponentInParent<TurretBase>();
        cluster = GetComponentInParent<TurretCluster>();
        if(minTimer > maxTimer)
        {
            float temp = minTimer;
            minTimer = maxTimer;
            maxTimer = temp;
        }
        currentTime = Random.Range(minTimer, maxTimer);
    }

    public void Teleport(TurretBase newParent)
    {
        if(parent != null)
        {
            parent.PlayParticles();
        }
        if(newParent != null)
        {
            parent = newParent;
            transform.parent = newParent.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            currentTime = Random.Range(minTimer, maxTimer);
            TurretBase newParent = cluster.Teleport(parent);
            Teleport(newParent);
        }
    }
}
