using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyDeath))]
[RequireComponent(typeof(BoxCollider))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPreference _preference;
    [SerializeField] private Transform _shootPoint;

    private Health _health;
    private EnemyMover _mover;
    private EnemyDeath _death;

    public event UnityAction<Enemy> Died;

    public bool IsAlive => _health.Value > 0;
    public Vector3 ShootPoint => _shootPoint.position;

    public void Initialize(Waypoint path)
    {
        _death = GetComponent<EnemyDeath>();
        _mover = GetComponent<EnemyMover>();
        _death.Initialize(this, _preference.SoundSettings);
        _mover.Initialize(path, _preference.GoingTime);
    }

    public static void CreateNew(Enemy template, Vector3 position, Waypoint path)
    {
        var enemy = Instantiate(template, position, Quaternion.identity);
        enemy.Initialize(path);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnEnable()
    {
        _health = GetComponent<Health>();
        _health.Initialize(_preference.MaxHealth);
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        if (IsAlive == false)
            Die();
    }

    private void Die()
    {
        Died?.Invoke(this);
        DOTween.Pause(gameObject);
        DOTween.Pause(gameObject.transform);
        Destroy(gameObject);
    }
}
