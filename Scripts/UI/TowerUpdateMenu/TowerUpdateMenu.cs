using UnityEngine;

[RequireComponent(typeof(UpdateMenuView))]
public class TowerUpdateMenu : MonoBehaviour
{
    [SerializeField] private SellButton _sellButton;
    [SerializeField] private UpdateButton _updateButton;
    [SerializeField] private GameObject _menuContainer;
    [SerializeField] private MoneyBlocker _moneyBlocker;
 
    [SerializeField] private float _verticalDistance;

    private UpdateMenuView _updateMenuView;
    private Vector3 _upperVector;

    private void OnEnable()
    {
        Mouse.ObjectClicked += OnObjectClicked;
        _updateMenuView = GetComponent<UpdateMenuView>();
        _upperVector = new Vector3(0, _verticalDistance, 0);
    }

    private void OnDisable()
    {
        Mouse.ObjectClicked -= OnObjectClicked;
    }

    private void OnObjectClicked(GameObject obj)
    {
        if (obj.TryGetComponent(out Tower tower))
            ShowMenu(tower);
    }

    private void ShowMenu(Tower tower)
    {
        _menuContainer.transform.position = tower.transform.position + _upperVector;
        _menuContainer.SetActive(true);
        _updateMenuView.Show(tower.GetPreference());
        _updateButton.ChooseCurrentTower(tower);
        _sellButton.ChooseCurrentTower(tower);
        _moneyBlocker.Initialize(tower.GetPreference().View.Price);
    }

    private void Update()
    {
        Vector3 direction = Camera.main.transform.forward;
        transform.forward = direction;
    }
}
