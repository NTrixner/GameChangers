using UnityEngine;

public abstract class Hitable : MonoBehaviour
{
    public abstract bool OnHit(GameObject origin);
}
