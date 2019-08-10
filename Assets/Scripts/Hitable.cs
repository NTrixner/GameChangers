using UnityEngine;

public abstract class Hitable : MonoBehaviour
{
    public abstract void OnHit(GameObject origin);
}
