using UnityEngine;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] private Button _button;

    private TowerGhost _currentGhost;
    private TowerGhost _ghostTemplate;

    private bool _isInitialized = false;

    public void Initialize(TowerGhost towerGhost)
    {
        _ghostTemplate = towerGhost;
        _isInitialized = true;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (_isInitialized && _currentGhost == null)
            _currentGhost = Instantiate(_ghostTemplate, Mouse.Position, Quaternion.identity);
    }
}
