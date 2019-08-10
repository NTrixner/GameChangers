using UnityEngine;

public class PlayerController : Hitable
{
    public float MovementMultiplier = 0.5f;
    

    private Transform Cam;
    private Vector3 CamForward;
    private Vector3 Movement;
    private FakerutoController Avatar;

    private Item currentItem;

    private HealthBarUI healthBar;
    private int health;
    private int maxHealth = 3;

    private void Start()
    {
        Cam = Camera.main.transform;
        Avatar = GetComponentInChildren<FakerutoController>();
        health = maxHealth;
        healthBar = FindObjectOfType<HealthBarUI>();
        currentItem = GetComponentInChildren<Item>();
    }

    private void Update()
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
        if (health != 0)
        {
            healthBar.SetHealth(--health);

            if (health == 0)
            {
                gameObject.SetActive(false);
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
}