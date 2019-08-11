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
    private float teleportTime = 10f;

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Color targetColor;

    [SerializeField]
    private float redTime = 0.1f;

    private float coolDownModifier = 1.0f;

    private float currentTargetTime = 2.5f;
    private float currentTimer = 0f;
    private float targetParticleSize = 0f;

    private float currentTeleportTargetTime = 10f;
    private float currentTeleportTime = 0f;

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        targetParticleSize = particles.transform.localScale.x;
        particles.transform.localScale = new Vector3(0f, 0f, 0f);
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        UpdateShotTimer();

        UpdateTeleportTimer();

        LookAtPlayer();
    }

    void UpdateShotTimer()
    {
        currentTimer += Time.deltaTime;
        if (currentTargetTime - currentTimer <= redTime)
        {
            var main = particles.main;

            Color oldColor = main.startColor.color;
            Color newColor = Color.Lerp(oldColor, targetColor, (currentTargetTime - currentTimer) / redTime);
            main.startColor = newColor;
        }
        else
        {
            var main = particles.main;
            main.startColor = Color.white;
        }

        if (currentTimer >= currentTargetTime)
        {
            currentTargetTime = Random.Range(randMin, randMax);
            currentTargetTime *= coolDownModifier;
            currentTimer = 0f;
            ShootProjectile();
        }

        float currentParticleSize = currentTimer / currentTargetTime * targetParticleSize;
        particles.transform.localScale = new Vector3(currentParticleSize, currentParticleSize, currentParticleSize);
    }

    void UpdateTeleportTimer()
    {
        currentTeleportTime += Time.deltaTime;
    }

    void TriggerTeleport()
    {
        if (currentTeleportTime >= currentTeleportTargetTime)
        {
            currentTeleportTargetTime = teleportTime;
            currentTargetTime *= coolDownModifier;
            currentTeleportTime = 0f;

            GetComponentInParent<TurretTeleport>().Teleport();
        }
    }

    void LookAtPlayer()
    {
        transform.LookAt(player.transform, Vector3.up);
        float rotY = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotY, 0));
    }

    void ShootProjectile()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.GetComponent<Bullet>().Origin = transform.parent.gameObject;
        obj.transform.rotation = transform.rotation;
        obj.transform.position = particles.transform.position;
        audioSource.Play();

        TriggerTeleport();
    }

    public void SetCooldown(float cd)
    {
        coolDownModifier = cd;
        currentTeleportTargetTime *= cd;
        currentTargetTime *= cd;
    }
}
