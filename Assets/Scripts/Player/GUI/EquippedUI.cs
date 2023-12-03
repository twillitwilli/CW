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
    Sprite[] equipmentUI;

    public void ChangePrimaryWeapon(int whichWeapon)
    {
        if (!_primaryWeapon.gameObject.activeSelf)
            _primaryWeapon.gameObject.SetActive(true);

        _primaryWeapon.sprite = equipmentUI[whichWeapon];
    }

    public void ChangeItem(int whichItem)
    {
        if (!_item.gameObject.activeSelf)
            _item.gameObject.SetActive(true);

        _item.sprite = equipmentUI[whichItem];
    }
}
