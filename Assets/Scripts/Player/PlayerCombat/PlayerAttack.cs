using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.Interfaces;

public class PlayerAttack : MonoBehaviour, iCooldownable
{
    public enum EquippedWeapon
    {
        none,
        spear,
        scythe,
        forgottenScythe
    }

    public EquippedWeapon currentEquippedWeapon;
    public bool weaponIdx { get; set; }

    public enum EquippedItem
    {
        none,
        magicKnifePouch,
        fireCrystal,
        ghostStaff,
        bookOfTruth,
        gravityCrystal,
        portalCrystal,
        magicHourGlass
    }

    public EquippedItem currentEquippedItem;
    public int itemIdx { get; set; }

    [SerializeField]
    PlayerProgress _playerProgress;

    [SerializeField]
    PlayerFacingDirection _facingDirection;

    [SerializeField]
    PlayerSpear _playerSpear;

    [SerializeField]
    PlayerWeaponController _weaponController;

    public PlayerItemController itemController;

    public bool isAttacking { get; set; }

    public float cooldownTimer { get; set; }

    EquippedUI _equippedUI;

    private void Start()
    {
        _equippedUI = EquippedUI.Instance;
    }

    private void Update()
    {
        if (CooldownDone(false, 0))
        {
            // Running Cooldown
        }
    }

    public void Attack()
    {
        switch (currentEquippedWeapon)
        {
            case EquippedWeapon.spear:

                if (!isAttacking)
                {
                    isAttacking = true;
                    _facingDirection.lockDirection = true;
                    _playerSpear.gameObject.SetActive(true);
                    _playerSpear.StrongAttack();
                }

                break;

            case EquippedWeapon.scythe:
                break;

            case EquippedWeapon.forgottenScythe:
                break;
        }

        
    }

    public void EquipWeapon(PlayerAttack.EquippedWeapon whichWeapon)
    {
        currentEquippedWeapon = whichWeapon;

        switch (whichWeapon)
        {
            case EquippedWeapon.spear:
                _equippedUI.ChangePrimaryWeapon(0);
                break;

            case EquippedWeapon.scythe:
                _equippedUI.ChangePrimaryWeapon(1);
                break;

            case EquippedWeapon.forgottenScythe:
                _equippedUI.ChangePrimaryWeapon(2);
                break;
        }
    }

    public void EquipItem(PlayerAttack.EquippedItem whichItem)
    {
        currentEquippedItem = whichItem;

        switch (whichItem)
        {
            case EquippedItem.magicKnifePouch:
                _equippedUI.ChangeItem(0);
                break;

            case EquippedItem.fireCrystal:
                _equippedUI.ChangeItem(1);
                break;

            case EquippedItem.ghostStaff:
                _equippedUI.ChangeItem(2);
                break;

            case EquippedItem.bookOfTruth:
                _equippedUI.ChangeItem(3);
                break;

            case EquippedItem.gravityCrystal:
                _equippedUI.ChangeItem(4);
                break;

            case EquippedItem.portalCrystal:
                _equippedUI.ChangeItem(5);
                break;

            case EquippedItem.magicHourGlass:
                _equippedUI.ChangeItem(6);
                break;
        }
    }

    public void NextItem()
    {
        if (_playerProgress.hasItem)
        {
            itemIdx++;
            if (itemIdx > _equippedUI.itemCount)
                itemIdx = 0;

            if (!CheckItem())
                NextItem();
        }
    }

    public void PreviousItem()
    {
        if (_playerProgress.hasItem)
        {
            itemIdx--;
            if (itemIdx < 0)
                itemIdx = _equippedUI.itemCount;

            if (!CheckItem())
                PreviousItem();
        }
    }

    private bool CheckItem()
    {
        switch (itemIdx)
        {
            case 0:

                if (_playerProgress.hasMagicKnifePouch)
                {
                    EquipItem(PlayerAttack.EquippedItem.magicKnifePouch);
                    return true;
                }
                break;

            case 1:

                if (_playerProgress.hasFireCrystal)
                {
                    EquipItem(PlayerAttack.EquippedItem.fireCrystal);
                    return true;
                }
                break;

            case 2:

                if (_playerProgress.hasGhostStaff)
                {
                    EquipItem(PlayerAttack.EquippedItem.ghostStaff);
                    return true;
                }
                break;

            case 3:

                if (_playerProgress.hasBookOfTruth)
                {
                    EquipItem(PlayerAttack.EquippedItem.bookOfTruth);
                    return true;
                }
                break;

            case 4:

                if (_playerProgress.hasGravityCrystal)
                {
                    EquipItem(PlayerAttack.EquippedItem.gravityCrystal);
                    return true;
                }
                break;

            case 5:

                if (_playerProgress.hasPortalCrystal)
                {
                    EquipItem(PlayerAttack.EquippedItem.portalCrystal);
                    return true;
                }
                break;

            case 6:

                if (_playerProgress.hasMagicHourglass)
                {
                    EquipItem(PlayerAttack.EquippedItem.magicHourGlass);
                    return true;
                }    
                break;
        }

        return false;
    }

    public void KineticForce()
    {
        GameObject newForce = KineticForcePool.Instance.GetObject();
        newForce.transform.position = transform.position;
        newForce.transform.rotation = transform.rotation;

        if (!newForce.activeSelf)
            newForce.SetActive(true);
    }

    public bool CooldownDone(bool setTimer, float cooldownTime)
    {
        if (setTimer)
            cooldownTimer = cooldownTime;

        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
            return true;

        return false;
    }
}
