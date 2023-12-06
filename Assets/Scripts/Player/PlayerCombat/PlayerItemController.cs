using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    [SerializeField]
    Player _player;

    [SerializeField]
    PlayerAttack _playerAttack;

    [SerializeField]
    GameObject
        _magicKnife,
        _fireball,
        _playerBody;

    public void UseItem()
    {
        switch (_playerAttack.currentEquippedItem)
        {
            case PlayerAttack.EquippedItem.magicKnifePouch:
                UseMagicKnife();
                break;

            case PlayerAttack.EquippedItem.fireCrystal:
                UseFireCrystal();
                break;

            case PlayerAttack.EquippedItem.ghostStaff:
                UseGhostStaff();
                break;

            case PlayerAttack.EquippedItem.bookOfTruth:
                UseBookOfTruth();
                break;

            case PlayerAttack.EquippedItem.gravityCrystal:
                UseGravityCrystal();
                break;

            case PlayerAttack.EquippedItem.portalCrystal:
                UsePortalCrystal();
                break;

            case PlayerAttack.EquippedItem.magicHourGlass:
                UseMagicHourglass();
                break;
        }
    }

    private void UseMagicKnife()
    {
        GameObject newKnife = Instantiate(_magicKnife, transform.position, transform.rotation);
        newKnife.transform.SetParent(null);
    }

    private void UseFireCrystal()
    {
        GameObject newKnife = Instantiate(_fireball, transform.position, transform.rotation);
        newKnife.transform.SetParent(null);
    }

    private void UseGhostStaff()
    {
        if (!_player.ghostForm)
        {
            _player.playerMimic = Instantiate(_playerBody, transform.position, _player.transform.rotation);
            _player.GhostForm(true);
        }
           

        else
            _player.GhostForm(false);
    }

    private void UseBookOfTruth()
    {
        Debug.Log("Use Book of Truth");
    }

    private void UseGravityCrystal()
    {
        Debug.Log("Use Gravity Crystal");
    }

    private void UsePortalCrystal()
    {
        Debug.Log("Use Portal Crystal");
    }

    private void UseMagicHourglass()
    {
        Debug.Log("Use Magic Hourglass");
    }
}
