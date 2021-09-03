using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingEffect : MonoBehaviour
{
    [SerializeField] protected ParticleSystem[] ParticleSystems;

    public abstract void Initialize(float reloadTime);

    public void StartShooting()
    {
        foreach (var particleSystem in ParticleSystems)
            particleSystem.Play();
    }

    public void StopShooting()
    {
        foreach (var particleSystem in ParticleSystems)
            particleSystem.Stop();
    }
}
