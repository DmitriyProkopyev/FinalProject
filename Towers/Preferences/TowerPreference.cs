using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerPreference : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private TowerView _towerView;
    [SerializeField] private TowerGhost _ghostTemplate;
    [SerializeField] private Tower _nextTower;

    public string Name => _name;
    public TowerView View => _towerView;
    public TowerGhost GhostTemplate => _ghostTemplate;
    public Tower NextTower => _nextTower;
}
