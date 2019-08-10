using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;
    void Update()
    {
        transform.position += transform.forward.normalized * speed * Time.deltaTime;
    }
}
