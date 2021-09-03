using UnityEngine;

[RequireComponent(typeof(BulletShooter))]
[RequireComponent(typeof(TowerRotator))]
[RequireComponent(typeof(TowerShootZone))]
public class MachineGunTower : Tower
{
    [SerializeField] private SingleAttackerPreference _preference;

    private BulletShooter _shooter;
    private TowerRotator _rotator;
    private TowerShootZone _shootZone;

    public override TowerPreference GetPreference() => _preference;

    protected override void Initialize()
    {
        _shootZone = GetComponent<TowerShootZone>();
        _shootZone.Initialize(_preference.Radius);

        _rotator = GetComponent<TowerRotator>();
        _rotator.Initialize(_preference.RotationTime);

        _shooter = GetComponent<BulletShooter>();
        _shooter.Initialize(_preference.Damage, _preference.ReloadTime, _preference.SoundSettings);
    }
}
