using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour
{
    private float _goingTime;
    private Waypoint _path;

    public void Initialize(Waypoint path, float goingTime)
    {
        _path = path;
        _goingTime = goingTime;
    }

    private void Start()
    {
        var tween = transform.DOPath(_path.Points, _goingTime, PathType.CatmullRom);
        tween.SetLookAt(0.0001f).SetEase(Ease.Linear);
    }
}
