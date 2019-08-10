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

    protected abstract void OnSuccess();

    protected abstract void OnFailure();
}
