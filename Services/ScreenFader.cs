using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image _blackScreen;

    public void Fade(float duration, params Action[] actions)
    {
        StartCoroutine(FadeAction(duration, actions));
    }

    private IEnumerator FadeAction(float duration, Action[] actions)
    {
        var fadeIn = _blackScreen.DOFade(1, duration);

        yield return fadeIn.WaitForCompletion();

        foreach (Action action in actions)
            action?.Invoke();

        _blackScreen.DOFade(0, duration);
    }
}
