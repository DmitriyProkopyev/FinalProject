using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerShootZone), typeof(SoundPlayer))]
public class BulletShooter : Shooter
{
    private Enemy _currentEnemy;
    private Coroutine _coroutine;

    protected override void OnLastEnemyChanged(Enemy enemy)
    {
        RestartShooting(enemy);

        _currentEnemy = enemy;
    }

    protected override IEnumerator Attack()
    {
        var wait = new WaitForSeconds(ReloadTime);
        ShootingEffect.StartShooting();

        while (true)
        {
            AttackEnemy(_currentEnemy);
            SoundPlayer.Play(SoundPlayer.SoundPlayingType.Single);
            yield return wait;
        }
    }

    private void RestartShooting(Enemy enemy)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        if (enemy != null)
            _coroutine = StartCoroutine(Attack());
        else
            ShootingEffect.StopShooting();
    }
}
