using UnityEngine;

[RequireComponent(typeof(FlameShooter))]
[RequireComponent(typeof(TowerRotator))]
[RequireComponent(typeof(TowerShootZone))]
public class FlamethrowerTower : Tower
{
    [SerializeField] private SingleAttackerPreference _preference;

    private FlameShooter _shooter;
    private TowerRotator _rotator;
    private TowerShootZone _shootZone;

    public override TowerPreference GetPreference() => _preference;

    protected override void Initialize()
    {
        _shootZone = GetComponent<TowerShootZone>();
        _shootZone.Initialize(_preference.Radius);

        _rotator = GetComponent<TowerRotator>();
        _rotator.Initialize(_preference.RotationTime);

        _shooter = GetComponent<FlameShooter>();
        _shooter.Initialize(_preference.Damage, _preference.ReloadTime, _preference.SoundSettings);
    }
}
