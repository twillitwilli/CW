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

    [SerializeField]
    PlayerFacingDirection _facingDirection;

    [SerializeField]
    PlayerSpear _playerSpear;

    public bool isAttacking { get; set; }

    public float cooldownTimer { get; set; }

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
