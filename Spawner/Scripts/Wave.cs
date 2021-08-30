using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Wave : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;
    [SerializeField] private float _delayBeforeStart;

    public float DelayBeforeStart => _delayBeforeStart;

    public event UnityAction WaveEnded;

    public void Begin(Vector3 position, Waypoint path)
    {
        StartCoroutine(Spawn(position, path));
    }

    private IEnumerator Spawn(Vector3 position, Waypoint path)
    {
        var wait = new WaitForSeconds(_delay);
        yield return new WaitForSeconds(_delayBeforeStart);

        for (int i = 0; i < _count; i++)
        {
            Enemy.CreateNew(_template, position, path);
            yield return wait;
        }

        WaveEnded?.Invoke();
    }
}
