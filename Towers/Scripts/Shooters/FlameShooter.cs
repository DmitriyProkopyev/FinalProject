using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerShootZone))]
[RequireComponent(typeof(SoundPlayer))]
public class FlameShooter : Shooter
{
    private Enemy _currentEnemy;
    private Coroutine _coroutine;

    private bool _soundPlaying = false;

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
            yield return wait;
        }
    }

    private void RestartShooting(Enemy enemy)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        if (enemy != null)
        {
            _coroutine = StartCoroutine(Attack());
            if (!_soundPlaying)
                SoundPlayer.Play(SoundPlayer.SoundPlayingType.Looped);
        }
        else
        {
            ShootingEffect.StopShooting();
            SoundPlayer.Stop();
        }
    }
}
