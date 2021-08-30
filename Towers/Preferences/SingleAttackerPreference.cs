using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Preference", menuName = "Tower/Create Tower Preference/Attacker/SingleAttacker", order = 51)]
public class SingleAttackerPreference : AttackerPreference
{
    [SerializeField] private float _rotationTime;

    public float RotationTime => _rotationTime;
}
