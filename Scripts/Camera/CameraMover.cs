using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _minPosition;
    [SerializeField] private Vector2 _maxPosition;

    private void Update() => Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minPosition.x, _maxPosition.x),
            transform.position.y, Mathf.Clamp(transform.position.z, _minPosition.y, _maxPosition.y));
    }
}
