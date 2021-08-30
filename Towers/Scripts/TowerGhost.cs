using UnityEngine;

public class TowerGhost : MonoBehaviour
{
    [SerializeField] private Tower _towerTemplate;
    [SerializeField] private Material _rightMaterial;
    [SerializeField] private Material _wrongMaterial;

    private MeshRenderer[] _meshRenderers;
    private TowerPlace _currentPlace;

    private bool _canSetTower = false;

    private void Start()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void Update()
    {
        transform.position = Mouse.Position;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_canSetTower && _currentPlace.IsFree)
                BecomeTower();
            else
                CancelSetting();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            CancelSetting();
    }

    private void OnEnable()
    {
        Mouse.SelectedObjectChanged += OnSelectedObjectChanged;
    }

    private void OnDisable()
    {
        Mouse.SelectedObjectChanged -= OnSelectedObjectChanged;
    }

    private void OnSelectedObjectChanged(GameObject selected)
    {
        if (selected.TryGetComponent(out TowerPlace place) && place.IsFree)
        {
            SetMaterial(_rightMaterial);
            _currentPlace = place;
            _canSetTower = true;
        }
        else
        {
            SetMaterial(_wrongMaterial);
            _canSetTower = false;
        }
    }

    private void SetMaterial(Material material)
    {
        foreach (MeshRenderer meshRenderer in _meshRenderers)
            meshRenderer.material = material;
    }

    private void BecomeTower()
    {
        Tower.CreateNew(_towerTemplate, _currentPlace);
        Destroy(gameObject);
    }

    private void CancelSetting()
    {
        Destroy(gameObject);
    }
}
