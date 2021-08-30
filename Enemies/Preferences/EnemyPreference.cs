using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Preference", menuName = "Enemy/Create Enemy Preference", order = 51)]

public class EnemyPreference : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _goingTime;
    [SerializeField] private SoundSettings _soundSettings;

    public float MaxHealth => _maxHealth;
    public float GoingTime => _goingTime;
    public SoundSettings SoundSettings => _soundSettings;
}
