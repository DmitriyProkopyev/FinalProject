using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpdateButton : MenuButton
{
    private Tower _tower;

    public uint UpdatePrice => _tower.GetPreference().NextTower.GetPreference().View.Price;

    protected override void OnClick()
    {
        var place = _tower.Place;
        var nextTower = _tower.GetPreference().NextTower;
        _tower.Delete();
        Tower.CreateNew(nextTower, place);
    }

    public void ChooseCurrentTower(Tower tower)
    {
        _tower = tower;
    }
}
