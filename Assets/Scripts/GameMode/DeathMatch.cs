public class DeathMatch : GameMode
{
    public int Target = 5;

    private int current = 0;

    public override void OnRobotDestroyed()
    {
        current++;

        if (current >= Target)
        {
            OnSuccess();
        }
    }

    public override void OnPlayerDeath()
    {
        OnFailure();
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
