using UnityEngine;

public class GlobalTimeStop : Item
{
    [SerializeField]
    private float cooldownTime = 3f;

    [SerializeField]
    private float cooldownTimer = 0f;

    private CooldownUI ui;

    private void Awake()
    {
        ui = FindObjectOfType<CooldownUI>();
    }

    void Update()
    {
        if (cooldownTimer <= cooldownTime)
        {
            cooldownTimer += Time.deltaTime;
            ui.UpdateState(cooldownTimer / cooldownTime);

            if (cooldownTimer >= cooldownTime)
            {
                ui.OnReady();
            }
        }
    }

    public override void UseItem()
    {
        if (cooldownTimer >= cooldownTime)
        {
            TurretTeleport[] enemies = FindObjectsOfType<TurretTeleport>();
            foreach (TurretTeleport e in enemies)
            {
                e.DisableTeleport();
            }

            ui.OnUsed();

            cooldownTimer = 0f;
        }
    }
}
