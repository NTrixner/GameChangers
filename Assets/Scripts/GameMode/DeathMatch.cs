using UnityEngine;

public class DeathMatch : GameMode
{
    public int Target = 5;

    public float maxCoolDownBonus = 0.3f;

    private int current = 0;

    private int enemyCount = 99;

    private void Start()
    {
        enemyCount = FindObjectsOfType<TurretTeleport>().Length;
    }

    public override void OnRobotDestroyed()
    {
        current++;

        if (current >= Target)
        {
            OnSuccess();
        }
        else
        {
            TurretShooter[] turrets = FindObjectsOfType<TurretShooter>();
            foreach (TurretShooter t in turrets)
            {
                float remaining = (enemyCount - current);
                float count = enemyCount;
                float cdBonus = Mathf.Max(remaining / count, maxCoolDownBonus);
                Debug.Log("Calc cooldown bonus to " + remaining / count);
                t.SetCooldown(cdBonus);
                Debug.Log("Set cooldown bonus to " + cdBonus);
            }
        }
    }

    public override void OnPlayerDeath()
    {
        OnFailure();
    }

    public override int GetShotsToTeleport()
    {
        throw new System.NotImplementedException();
    }

    public override float GetShotCooldownModifier()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnFailure()
    {
        FindObjectOfType<LevelManager>().ShowDeathScreen();
    }

    protected override void OnSuccess()
    {
        FindObjectOfType<LevelManager>().ShowSuccessScreen();
    }
}
