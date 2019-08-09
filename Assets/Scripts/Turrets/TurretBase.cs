using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    public void PlayParticles()
    {
        if(particles != null)
        {
            particles.Play();
        }
    }
}
