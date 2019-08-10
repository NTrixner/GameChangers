using UnityEngine;

public class GlobalTimeStop : Item
{
    [SerializeField]
    private float cooldownTime = 3f;

    [SerializeField]
    private float disableDuration = 2.5f;

    private float cooldownTimer = 0f;

    private CooldownUI ui;

    private PlayerController player;

    private void Awake()
    {
        ui = FindObjectOfType<CooldownUI>();
        player = GetComponentInParent<PlayerController>();
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
            Disabler[] disablers = FindObjectsOfType<Disabler>();
            foreach (Disabler d in disablers)
            {
                d.Disable(disableDuration);
            }

            ui.OnUsed();

            cooldownTimer = 0f;
        }
    }
}
