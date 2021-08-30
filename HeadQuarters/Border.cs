using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Border : MonoBehaviour
{
    private BoxCollider _border;

    public event UnityAction Crossed;

    private void Start()
    {
        _border = GetComponent<BoxCollider>();
        _border.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            OnEnemyEntered(enemy);
    }

    private void OnEnemyEntered(Enemy enemy)
    {
        Crossed?.Invoke();
        Destroy(enemy.gameObject);
    }
}
