using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MenuCameraMover : MonoBehaviour
{
    [SerializeField] private Waypoint _path;
    [SerializeField] private float _duration;
    [SerializeField] private float _percentsOfTime;
    [SerializeField] private ScreenFader _fader;

    private const float RotationSpeed = 0.01f;

    private void Start()
    {
        var tween = transform.DOPath(_path.Points, _duration, PathType.CatmullRom);
        tween.SetLookAt(RotationSpeed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        StartCoroutine(FadeOnRestart());
    }

    private IEnumerator FadeOnRestart()
    {
        while (true)
        {
            float waitingTime = TakePercents(_duration, _percentsOfTime);

            var wait = new WaitForSeconds(_duration - waitingTime);
            yield return wait;

            _fader.Fade(waitingTime);
        }
    }

    private float TakePercents(float value, float percents) => value / 100 * percents;
}
