using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMenuView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sellPrice;
    [SerializeField] private TMP_Text _updatePrice;
    [SerializeField] private Image _image;

    public void Show(TowerPreference preference)
    {
        var menu = _updatePrice.transform.parent.gameObject;

        var next = preference.NextTower;
        TowerPreference nextPreference;

        uint sellPrice = preference.View.SellPrice;
        _sellPrice.text = ("+" + sellPrice).ToString();

        if (next != null)
        {
            menu.SetActive(true);

            nextPreference = preference.NextTower.GetPreference();

            uint nextTowerPrice = nextPreference.View.Price;

            _updatePrice.text = nextTowerPrice.ToString();
            _image.sprite = nextPreference.View.Icon;
        }
        else
        {
            _updatePrice.text = string.Empty;
            _image.sprite = null;
            menu.SetActive(false);
        } 
    }
}
