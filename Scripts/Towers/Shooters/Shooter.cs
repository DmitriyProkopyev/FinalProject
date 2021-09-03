using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerShootZone), typeof(SoundPlayer))]
public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected ShootingEffect ShootingEffect;

    protected TowerShootZone ShootZone;
    protected Coroutine Shooting;
    protected SoundPlayer SoundPlayer;

    protected float ReloadTime { get; private set; }
    protected float Damage { get; private set; }

    public void Initialize(float damage, float reloadTime, SoundSettings settings)
    {
        Damage = damage;
        ReloadTime = reloadTime;
        ShootingEffect.Initialize(reloadTime);
        SoundPlayer = GetComponent<SoundPlayer>();
        SoundPlayer.Initialize(settings);
        OnSoundPlayerSet();
    }

    private void OnEnable()
    {
        ShootZone = GetComponent<TowerShootZone>();
        ShootZone.LastEnemyChanged += OnLastEnemyChanged;
        ShootZone.EnemiesChanged += OnEnemiesChanged;
    }

    private void OnDisable()
    {
        ShootZone.LastEnemyChanged -= OnLastEnemyChanged;
        ShootZone.EnemiesChanged -= OnEnemiesChanged;
    }

    protected virtual void OnLastEnemyChanged(Enemy enemy) { }

    protected virtual void OnEnemiesChanged(IEnumerable<Enemy> enemies) { }

    protected abstract IEnumerator Attack();

    protected virtual void OnSoundPlayerSet() { }

    protected void AttackEnemy(Enemy enemy)
    {
        if (enemy != null)
            enemy.TakeDamage(Damage);
    }
}
