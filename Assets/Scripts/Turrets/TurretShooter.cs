using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float randMin = 2f;

    [SerializeField]
    private float randMax = 5f;

    [SerializeField]
    private ParticleSystem particles;

    private float currentTargetTime = 5;
    private float currentTimer = 0f;
    private float targetParticleSize = 0f;

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        targetParticleSize = particles.transform.localScale.x;
        particles.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer >= currentTargetTime)
        {
            currentTargetTime = Random.Range(randMin, randMax);
            currentTimer = 0f;
            ShootProjectile();
        }
        float currentParticleSize = currentTimer / currentTargetTime * targetParticleSize;
        particles.transform.localScale = new Vector3(currentParticleSize, currentParticleSize, currentParticleSize);
    }

    void ShootProjectile()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.rotation = transform.rotation;
        obj.transform.position = particles.transform.position;
    }
}
