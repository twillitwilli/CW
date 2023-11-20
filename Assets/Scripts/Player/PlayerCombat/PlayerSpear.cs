using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpear : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    PlayerAttack _playerAttack;

    [SerializeField]
    PlayerStats _playerStats;

    [SerializeField]
    PlayerFacingDirection _facingDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy;

        if (collision.TryGetComponent<Enemy>(out enemy))
            enemy.Damage(-_playerStats.attackDamage);

        Breakable breakable;

        if (collision.TryGetComponent<Breakable>(out breakable))
        {
            breakable.Damage(-_playerStats.attackDamage);
        }
    }

    public void WeakAttack()
    {
        _animator.Play("SpearStab");
    }

    public void StrongAttack()
    {
        _animator.Play("SpearSwipe");
    }

    public void AttackDone()
    {
        _playerAttack.isAttacking = false;
        _facingDirection.lockDirection = false;
        gameObject.SetActive(false);
    }
}
