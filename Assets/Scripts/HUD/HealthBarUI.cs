using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private HealthUI[] healthItems;

    private int maxHealth;

    private void Awake()
    {
        if(healthItems != null)
        {
            maxHealth = healthItems.Length;
        }
    }

    public void SetHealth(int health)
    {
        if (health < 0) health = 0;
        if (health > maxHealth) health = maxHealth;

        for (int i = 0; i < health; ++i)
        {
            healthItems[i].SetFull();
        }

        for (int i = health; i < maxHealth; ++i)
        {
            healthItems[i].SetEmpty();
        }
    }
}
