using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaShooter))]
[RequireComponent(typeof(TowerShootZone))]

public class EnergyTower : Tower
{
    [SerializeField] private MultipleAtackerPreference _preference;

    private AreaShooter _shooter;
    private TowerShootZone _shootZone;

    public override TowerPreference GetPreference() => _preference;

    protected override void Initialize()
    {
        _shootZone = GetComponent<TowerShootZone>();
        _shootZone.Initialize(_preference.Radius);

        _shooter = GetComponent<AreaShooter>();
        _shooter.Initialize(_preference.Damage, _preference.ReloadTime, _preference.SoundSettings);
    }
}
