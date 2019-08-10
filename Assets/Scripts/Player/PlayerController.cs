using UnityEngine;

public class PlayerController : Hitable
{
    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private float MovementMultiplier = 0.5f;

    [SerializeField]
    private float onHitInvincibility = 2.0f;

    private Transform Cam;
    private Vector3 CamForward;
    private Vector3 Movement;
    private FakerutoController Avatar;

    private Item currentItem;

    private HealthBarUI healthBar;
    private int health;
    private int maxHealth = 3;

    private float remainingInvincibility = 0.0f;

    private Disabler disabler;
    private bool isDisabled = false;

    private void Start()
    {
        Cam = Camera.main.transform;
        Avatar = GetComponentInChildren<FakerutoController>();
        health = maxHealth;
        healthBar = FindObjectOfType<HealthBarUI>();
        currentItem = GetComponentInChildren<Item>();

        disabler = GetComponent<Disabler>();
        disabler.OnDisableEvent += OnMovementDisabled;
        disabler.OnEnableEvent += OnMovementEnabled;
    }

    private void Update()
    {
        if (!isDisabled)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            CamForward = Vector3.Scale(Cam.forward, new Vector3(1, 0, 1)).normalized;
            Movement = v * CamForward + h * Cam.right;

            Avatar.Move(Movement * MovementMultiplier);

            if (Input.GetKey(KeyCode.J))
            {
                currentItem.UseItem();
            }
        }

        if (remainingInvincibility > 0.0f)
        {
            remainingInvincibility -= Time.deltaTime;
        }
        else
        {
            Avatar.SetInvincible(false);
        }
    }
    
    public override bool OnHit(GameObject origin)
    {
        if (origin != gameObject)
        {
            LoseHealth();
            return true;
        }

        return false;
    }

    public void LoseHealth()
    {
        if ((health != 0) && (remainingInvincibility <= 0.0f))
        {
            healthBar.SetHealth(--health);

            if (health == 0)
            {
                GameMode.Instance.OnPlayerDeath();
            }
            else
            {
                StartInvincibility();
            }
        }
    }

    public void GainHealth()
    {
        if (health != maxHealth)
        {
            healthBar.SetHealth(++health);
        }
    }

    private void StartInvincibility()
    {
        remainingInvincibility = onHitInvincibility;
        Avatar.SetInvincible(true);
    }

    private void OnMovementDisabled()
    {
        isDisabled = true;
    }

    private void OnMovementEnabled()
    {
        isDisabled = false;
    }
}