using UnityEngine;

public abstract class GameMode : MonoBehaviour
{
    private static GameMode currentInstance;

    public static GameMode Instance {
        get {
            if (currentInstance == null)
            {
                currentInstance = FindObjectOfType<GameMode>();
            }

            return currentInstance;
        }
    }

    public abstract void OnRobotDestroyed();

    public abstract void OnPlayerDeath();

    public abstract int GetShotsToTeleport();

    public abstract float GetShotCooldownModifier();

    protected abstract void OnSuccess();

    protected abstract void OnFailure();
}
