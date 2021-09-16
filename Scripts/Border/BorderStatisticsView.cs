using TMPro;
using UnityEngine;

public class BorderStatisticsView : MonoBehaviour
{
    [SerializeField] private Border _border;
    [SerializeField] private TMP_Text _text;

    private readonly uint _startAttempts = 5;
    private uint _crossesLeft;

    private void OnEnable()
    {
        _border.Crossed += OnBorderCrossed;
        _crossesLeft = _startAttempts + 1;
        OnBorderCrossed();
    }

    private void OnDisable() => _border.Crossed -= OnBorderCrossed;

    private void OnBorderCrossed()
    {
        if (_crossesLeft > 0)
            _crossesLeft--;
        _text.text = _crossesLeft.ToString();
    }
}
