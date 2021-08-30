using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TowerRotator))]
[RequireComponent(typeof(SoundPlayer))]
public class MoneyEarnTower : Tower
{
    [SerializeField] private MoneyTowerPreference _preference;

    private TowerRotator _rotator;
    private SoundPlayer _soundPlayer;

    public override TowerPreference GetPreference() => _preference;

    protected override void Initialize()
    {
        _rotator = GetComponent<TowerRotator>();
        _rotator.Initialize(_preference.RotationTime);

        _soundPlayer = GetComponent<SoundPlayer>();
        _soundPlayer.Initialize(_preference.SoundSettings);

        StartCoroutine(Earn(_preference.WaitingTime, _preference.MoneyPerTime));
    }

    private IEnumerator Earn(float waitingTime, uint moneyPerTime)
    {
        var wait = new WaitForSeconds(waitingTime);
        _soundPlayer.Play(SoundPlayer.SoundPlayingType.Looped);

        while (true)
        {
            MoneyStorage.AddMoney(moneyPerTime);
            yield return wait;
        }
    }
}
