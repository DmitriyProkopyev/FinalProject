using UnityEngine;

public class BulletShootingEffect : ShootingEffect
{
    private ParticleSystem.Burst _burst;

    public override void Initialize(float reloadTime)
    {
        _burst = new ParticleSystem.Burst();
        _burst.repeatInterval = reloadTime;
        _burst.count = 1;
        _burst.cycleCount = 0;

        foreach (ParticleSystem particleSystem in ParticleSystems)
            particleSystem.emission.SetBurst(0, _burst);
    }
}
