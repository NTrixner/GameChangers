using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private HealthUI[] healthItems;

    int health;

    private void Awake()
    {
        if(healthItems != null)
        {
            health = healthItems.Length;
        }
    }

    public void LoseHealth()
    {
        if(health != 0)
        {
            healthItems[health - 1].SetEmpty();
            health--;
        }
    }

    public void GainHealth()
    {
        if(health != healthItems.Length)
        {
            health++;
            healthItems[health - 1].SetFull();
        }
    }
}
