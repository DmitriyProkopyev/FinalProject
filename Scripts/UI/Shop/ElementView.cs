using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TowerPlacer _placer;
    [SerializeField] private MoneyBlocker _moneyBlocker;

    public void Render(TowerPreference preference)
    {
        uint towerPrice = preference.View.Price;

        _image.sprite = preference.View.Icon;
        _text.text = towerPrice.ToString();
        _placer.Initialize(preference.GhostTemplate);
        _moneyBlocker.Initialize(towerPrice);
    }
}
