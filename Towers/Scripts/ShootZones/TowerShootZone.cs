using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class TowerShootZone : MonoBehaviour
{
    private SphereCollider _shootZone;
    private List<Enemy> _enemies;

    private float _radius;

    public IEnumerable<Enemy> EnemiesInZone => _enemies;

    public event UnityAction<Enemy> LastEnemyChanged;
    public event UnityAction<IEnumerable<Enemy>> EnemiesChanged;

    public void Initialize(float radius)
    {
        _radius = radius;

        _shootZone = GetComponent<SphereCollider>();
        _enemies = new List<Enemy>();
        _shootZone.isTrigger = true;
        _shootZone.radius = _radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            AddEnemy(enemy);

        if (_enemies.Count == 1)
            LastEnemyChanged?.Invoke(_enemies[0]);

        EnemiesChanged?.Invoke(_enemies);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            RemoveEnemy(enemy);

        EnemiesChanged?.Invoke(_enemies);
    }

    private void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.Died += RemoveEnemy;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.Died -= RemoveEnemy;
        LastEnemyChanged?.Invoke(_enemies.Count == 0 ? null : _enemies[0]);
    }
}
