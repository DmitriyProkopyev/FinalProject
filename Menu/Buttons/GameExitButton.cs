using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitButton : MenuButton
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
