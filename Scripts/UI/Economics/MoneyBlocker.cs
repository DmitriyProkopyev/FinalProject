using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBlocker : MonoBehaviour
{
    [SerializeField] private GameObject _moneyBlocker;

    private uint _price;

    public void Initialize(uint price)
    {
        _price = price;
        if (_moneyBlocker == gameObject)
            throw new System.Exception("Money blocker can't use itself as a block!");
    }

    private void OnEnable()
    {
        MoneyStorage.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(0);
    }

    private void OnDisable()
    {
        MoneyStorage.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(uint money)
    {
        _moneyBlocker.SetActive(!MoneyStorage.IsEnough(_price));
    }
}
