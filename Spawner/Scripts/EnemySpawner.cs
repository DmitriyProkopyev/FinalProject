using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Waypoint _path;

    private Wave _currentWave;
    private int _currentWaveNumber;

    public event UnityAction AllWavesEnded;

    private void Start()
    {
        _currentWaveNumber = 0;
        _currentWave = _waves[0];
        OnWaveEnded();
    }

    private void OnWaveEnded()
    {
        StartCoroutine(WaitAndStart(_currentWave.DelayBeforeStart));
    }

    private void BeginNextWave()
    {
        if (_currentWaveNumber > 0)
            _waves[_currentWaveNumber - 1].WaveEnded -= OnWaveEnded;
        _currentWave = _waves[_currentWaveNumber++];
        _currentWave.WaveEnded += OnWaveEnded;
        _currentWave.Begin(transform.position, _path);
    }

    private IEnumerator WaitAndStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (_currentWaveNumber != _waves.Count)
            BeginNextWave();
        else
            AllWavesEnded?.Invoke();
    }
}
