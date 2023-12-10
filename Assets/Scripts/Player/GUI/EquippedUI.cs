using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QTArts.AbstractClasses;

public class EquippedUI : MonoSingleton<EquippedUI>
{
    [SerializeField]
    Image
        _primaryWeapon,
        _item;

    [SerializeField]
    Sprite[] _weaponUI;

    [SerializeField]
    Sprite[] _itemUI;

    public int itemCount { get; private set; }

    private void Start()
    {
        itemCount = _itemUI.Length;
    }

    public void ChangePrimaryWeapon(int whichWeapon)
    {
        if (!_primaryWeapon.gameObject.activeSelf)
            _primaryWeapon.gameObject.SetActive(true);

        _primaryWeapon.sprite = _weaponUI[whichWeapon];
    }

    public void ChangeItem(int whichItem)
    {
        if (!_item.gameObject.activeSelf)
            _item.gameObject.SetActive(true);

        _item.sprite = _itemUI[whichItem];
    }
}
