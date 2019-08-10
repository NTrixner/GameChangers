using UnityEngine;

public class TurretTeleport : Hitable
{
    [SerializeField]
    private TurretBase parent;

    [SerializeField]
    private TurretCluster cluster;

    [SerializeField]
    private Shield shield;

    [SerializeField]
    private Collider bodyCollider;

    [SerializeField]
    private TurretShooter shooter;

    [SerializeField]
    private ParticleSystem sparks;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private AudioSource explosionSound;

    private float disableDuration = 0.0f;

    private void Awake()
    {
        parent = GetComponentInParent<TurretBase>();
        cluster = GetComponentInParent<TurretCluster>();
        shield = GetComponentInChildren<Shield>();
        bodyCollider = GetComponent<CapsuleCollider>();
        shooter = GetComponentInChildren<TurretShooter>();
        
        sparks.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (disableDuration > 0.0f)
        {
            disableDuration -= Time.deltaTime;

            if (disableDuration <= 0.0f)
            {
                EnableTeleport();
            }
        }
    }

    public void Teleport()
    {
        TurretBase newParent = cluster.Teleport(parent);

        if (parent != null)
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

    public override bool OnHit(GameObject origin)
    {
        if (origin == null || origin != gameObject)
        {
            explosion.Play();
            explosionSound.Play();
            InvokeRepeating("OnTurretDestroyed", explosion.main.duration, 0);
            return true;
        }

        return false;
    }

    public void OnTurretDestroyed()
    {
        GameMode.Instance.OnRobotDestroyed();
        Destroy(gameObject);
    }

    public void DisableTeleport(float duration)
    {
        shield.gameObject.SetActive(false);
        bodyCollider.enabled = true;
        disableDuration = duration;
        shooter.enabled = false;
        sparks.gameObject.SetActive(true);
    }

    public void EnableTeleport()
    {
        shield.gameObject.SetActive(true);
        bodyCollider.enabled = false;
        shooter.enabled = true;
        sparks.gameObject.SetActive(false);
    }
}
