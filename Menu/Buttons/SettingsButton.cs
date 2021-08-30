using UnityEngine;

public class SettingsButton : MenuButton
{
    [SerializeField] private GameObject _settingsPanel;

    protected override void OnClick()
    {
        _settingsPanel.SetActive(true);
    }
}
