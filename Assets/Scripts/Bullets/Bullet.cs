using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Origin { get; set; }

    [SerializeField]
    private float speed = 10f;

    private float TTL = 10f;

    void Update()
    {
        transform.position += transform.forward.normalized * speed * Time.deltaTime;

        TTL -= Time.deltaTime;
        if (TTL <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hitable hitObject = other.gameObject.GetComponent<Hitable>();
        if (hitObject != null)
        {
            if (hitObject.OnHit(Origin))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Origin = null;
    }
}
