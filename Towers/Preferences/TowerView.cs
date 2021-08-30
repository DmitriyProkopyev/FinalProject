using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerView", menuName = "Tower/Create Tower View", order = 51)]
public class TowerView : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private uint _price;
    [SerializeField] private uint _sellPrice;

    public Sprite Icon => _icon;
    public uint Price => _price;
    public uint SellPrice => _sellPrice;
}
