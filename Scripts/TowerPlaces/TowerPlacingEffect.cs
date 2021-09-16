using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacingEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void Play() => _effect.Play();
}
