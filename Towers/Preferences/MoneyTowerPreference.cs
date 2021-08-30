using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Preference", menuName = "Tower/Create Tower Preference/MoneyEarn/MoneyEarner", order = 51)]
public class MoneyTowerPreference : TowerPreference
{
    [SerializeField] private float _waitingTime;
    [SerializeField] private float _rotationTime;
    [SerializeField] private uint _moneyPerTime;
    [SerializeField] private SoundSettings _soundSettings;

    public float WaitingTime => _waitingTime;
    public float RotationTime => _rotationTime;
    public uint MoneyPerTime => _moneyPerTime;
    public SoundSettings SoundSettings => _soundSettings;
}
