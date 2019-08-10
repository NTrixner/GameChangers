using UnityEngine;

public class Shield : Hitable
{
    private TurretTeleport turretParent;

    private void OnEnable()
    {
        turretParent = GetComponentInParent<TurretTeleport>();
    }

    public override bool OnHit(GameObject origin)
    {
        if (origin == null || origin != transform.parent.gameObject)
        {
            turretParent.Teleport();
        }

        return false;
    }
}
