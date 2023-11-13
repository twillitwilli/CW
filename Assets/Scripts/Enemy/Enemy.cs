using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.Interfaces;

public class Enemy : MonoBehaviour, iDamagable<int>
{
    [SerializeField]
    float
        _maxHealth,
        _speed;

    public float Health { get; set; }

    Player _player;

    private void Start()
    {
        Health = _maxHealth;

        _player = Player.Instance;
    }

    private void Update()
    {
        if (!_player.playerStats.isDead)
            ChasePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats playerStats;

        if (collision.TryGetComponent<PlayerStats>(out playerStats))
            playerStats.Damage(1);
    }

    private void ChasePlayer()
    {
        AimAtTarget(_player.transform);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    public virtual void AimAtTarget(Transform target)
    {
        transform.up = transform.position - target.position;
    }

    public void Damage(int damageAmount)
    {
        Health += damageAmount;

        if (Health <= 0)
            Death();
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
