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
    public bool itemIdx { get; set; }

    [SerializeField]
    PlayerFacingDirection _facingDirection;

    [SerializeField]
    PlayerSpear _playerSpear;

    [SerializeField]
    PlayerWeaponController _weaponController;

    [SerializeField]
    PlayerItemController _itemController;

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
                _equippedUI.ChangeItem(4);
                break;

            case EquippedItem.fireCrystal:
                _equippedUI.ChangeItem(5);
                break;

            case EquippedItem.ghostStaff:
                _equippedUI.ChangeItem(6);
                break;

            case EquippedItem.bookOfTruth:
                _equippedUI.ChangeItem(7);
                break;

            case EquippedItem.gravityCrystal:
                _equippedUI.ChangeItem(8);
                break;

            case EquippedItem.portalCrystal:
                _equippedUI.ChangeItem(9);
                break;

            case EquippedItem.magicHourGlass:
                _equippedUI.ChangeItem(10);
                break;
        }
    }

    public void NextItem()
    {

    }

    public void PreviousItem()
    {

    }

    public void UseItem()
    {
        switch (currentEquippedItem)
        {
            case EquippedItem.magicKnifePouch:
                break;

            case EquippedItem.fireCrystal:
                break;

            case EquippedItem.ghostStaff:
                break;

            case EquippedItem.bookOfTruth:
                break;

            case EquippedItem.gravityCrystal:
                break;

            case EquippedItem.portalCrystal:
                break;

            case EquippedItem.magicHourGlass:
                break;
        }
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
