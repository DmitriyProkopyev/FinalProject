using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SellButton : MenuButton
{
    private Tower _tower;

    protected override void OnClick()
    {
        MoneyStorage.AddMoney(_tower.GetPreference().View.SellPrice);
        _tower.Delete();
    }

    public void ChooseCurrentTower(Tower tower)
    {
        _tower = tower;
    }
}
