using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    PlayerFacingDirection _facingDirection;

    [SerializeField]
    PlayerSpear _playerSpear;

    public bool isAttacking { get; set; }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            _facingDirection.lockDirection = true;
            _playerSpear.gameObject.SetActive(true);
            _playerSpear.StrongAttack();
        }
    }
}
