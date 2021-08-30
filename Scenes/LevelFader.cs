using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelFader : MonoBehaviour
{
    [SerializeField] private Image _blackScreen;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private float _startDuration;
    [SerializeField] private float _endDuration;

    private void Start()
    {
        _blackScreen.DOFade(0, _startDuration);
    }

    private void OnEnable()
    {
        if (_spawner != null)
            _spawner.AllWavesEnded += OnAllWavesEnded;
    }

    private void OnDisable()
    {
        if (_spawner != null)
            _spawner.AllWavesEnded -= OnAllWavesEnded;
    }

    private void OnAllWavesEnded()
    {
        _blackScreen.DOFade(1, _endDuration);
    }
}
