using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour
{
    private float _goingTime;
    private Waypoint _path;

    private const float RotationSpeed = 0.0001f;

    public void Initialize(Waypoint path, float goingTime)
    {
        _path = path;
        _goingTime = goingTime;
    }

    private void Start()
    {
        var tween = transform.DOPath(_path.Points, _goingTime, PathType.CatmullRom);
        tween.SetLookAt(RotationSpeed).SetEase(Ease.Linear);
    }
}
