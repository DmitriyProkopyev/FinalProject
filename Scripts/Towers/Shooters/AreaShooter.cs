using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TowerShootZone), typeof(SoundPlayer))]
public class AreaShooter : Shooter
{
    private IEnumerable<Enemy> _currentEnemies;

    protected override IEnumerator Attack()
    {
        var wait = new WaitForSeconds(ReloadTime);
        ShootingEffect.StartShooting();

        while (true)
        {
            foreach (Enemy enemy in _currentEnemies.ToList())
                AttackEnemy(enemy);

            yield return wait;
        }
    }

    protected override void OnEnemiesChanged(IEnumerable<Enemy> enemies)
    {
        if (Shooting != null)
            StopCoroutine(Shooting);

        _currentEnemies = enemies;

        if (enemies != null && _currentEnemies.Count() > 0)
            Shooting = StartCoroutine(Attack());
        else
            ShootingEffect.StopShooting();
    }

    protected override void OnSoundPlayerSet()
    {
        SoundPlayer.Play(SoundPlayer.SoundPlayingType.Looped);
    }
}
