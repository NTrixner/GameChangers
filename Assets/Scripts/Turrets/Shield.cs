using UnityEngine;

public class Shield : Hitable
{
    private TurretTeleport turretParent;

    private void OnEnable()
    {
        turretParent = GetComponentInParent<TurretTeleport>();
    }

    public override void OnHit(GameObject origin)
    {
        if (origin == null || origin != transform.parent.gameObject)
        {
            turretParent.Teleport();
        }
    }
}
