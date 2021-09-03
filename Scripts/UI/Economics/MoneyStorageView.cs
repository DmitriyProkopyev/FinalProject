using UnityEngine;
using TMPro;

public class MoneyStorageView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentMoney;

    private void OnEnable()
    {
        MoneyStorage.MoneyChanged += OnMoneyChanged;
        MoneyStorage.Initialize();
    }

    private void OnDisable()
    {
        MoneyStorage.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(uint money)
    {
        _currentMoney.text = money.ToString();
    }
}
