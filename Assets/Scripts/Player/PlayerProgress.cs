using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    [SerializeField]
    PlayerAttack _playerAttack;

    public bool
     hasSpear,
     hasScythe,
     hasTheForgottenScythe,
     hasMagicGlove,
     hasMagicKnifePouch,
     hasFireCrystal,
     hasGhostStaff,
     hasBookOfTruth,
     hasGravityCrystal,
     hasPortalCrystal,
     hasMagicHourglass;

    public void ObtainedWeapon(PlayerAttack.EquippedWeapon equipWeapon)
    {
        _playerAttack.currentEquippedWeapon = equipWeapon;
        _playerAttack.EquipWeapon(equipWeapon);
    }

    public void ObtainedItem(PlayerAttack.EquippedItem equipItem)
    {
        if (_playerAttack.currentEquippedItem == PlayerAttack.EquippedItem.none)
        {
            _playerAttack.currentEquippedItem = equipItem;
            _playerAttack.EquipItem(equipItem);
        }
    }
}
