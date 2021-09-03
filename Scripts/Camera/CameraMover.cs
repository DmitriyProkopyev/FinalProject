using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minX;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxX;
    [SerializeField] private float _maxZ;

    private void Update()
    {
        TryMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    private void TryMove(Vector3 direction)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX, _maxX),
            transform.position.y, Mathf.Clamp(transform.position.z, _minZ, _maxZ));
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
