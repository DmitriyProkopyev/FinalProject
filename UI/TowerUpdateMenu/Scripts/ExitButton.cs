using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MenuButton
{
    [SerializeField] private GameObject _menu;

    protected override void OnClick()
    {
        _menu.SetActive(false);
    }
}
