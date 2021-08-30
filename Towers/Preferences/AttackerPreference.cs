using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerPreference : TowerPreference
{
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _reloadTime;
    [SerializeField] private SoundSettings _settings;

    public float Damage => _damage;
    public float Radius => _radius;
    public float ReloadTime => _reloadTime;
    public SoundSettings SoundSettings => _settings;
}
