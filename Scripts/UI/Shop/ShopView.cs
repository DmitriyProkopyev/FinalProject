using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] private TowerPreference[] _towersPreferences;
    [SerializeField] private ElementView _elementTemplate;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        foreach (var preference in _towersPreferences)
            AddElement(preference);
    }

    private void AddElement(TowerPreference preference)
    {
        Instantiate(_elementTemplate, _container.transform).Render(preference);
    }
}
