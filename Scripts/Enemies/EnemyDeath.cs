using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffectTemplate;

    private Enemy _currentEnemy;
    private SoundPlayer _soundPlayer;

    public void Initialize(Enemy enemy, SoundSettings settings)
    {
        _currentEnemy = enemy;
        _currentEnemy.Died += OnDied;
        _soundPlayer = new GameObject().AddComponent<SoundPlayer>();
        _soundPlayer.transform.parent = transform;
        _soundPlayer.Initialize(settings);
    }

    private void OnEnable()
    {
        if (_currentEnemy != null)
            _currentEnemy.Died += OnDied;
    }

    private void OnDisable()
    {
        if (_currentEnemy != null)
            _currentEnemy.Died -= OnDied;
    }

    private void OnDied(Enemy enemy)
    {
        var effect = Instantiate(_deathEffectTemplate, enemy.ShootPoint, Quaternion.identity);
        effect.transform.parent = null;
        effect.Play();

        _soundPlayer.transform.parent = null;
        _soundPlayer.Play(SoundPlayer.SoundPlayingType.Single, SoundPlayer.ActionAfterPlay.SelfDestroy);
    }
}
