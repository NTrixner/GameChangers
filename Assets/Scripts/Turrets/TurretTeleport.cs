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

    private void Awake()
    {
        parent = GetComponentInParent<TurretBase>();
        cluster = GetComponentInParent<TurretCluster>();
        shield = GetComponentInChildren<Shield>();
        bodyCollider = GetComponent<CapsuleCollider>();
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

    public override void OnHit(GameObject origin)
    {
        if (origin == null || origin != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public void DisableTeleport()
    {
        shield.gameObject.SetActive(false);
        bodyCollider.enabled = true;
    }

    public void EnableTeleport()
    {
        shield.gameObject.SetActive(true);
        bodyCollider.enabled = false;
    }
}
