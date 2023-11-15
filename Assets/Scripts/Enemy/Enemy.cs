using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using QTArts.Interfaces;

public class Enemy : MonoBehaviour, iDamagable<int>
{
    [SerializeField]
    float
        _maxHealth,
        _speed;

    public float Health { get; set; }

    [SerializeField]
    SpriteRenderer _renderer;

    [SerializeField]
    Color
        normalColor,
        hitColor;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats playerStats;

        if (collision.gameObject.TryGetComponent<PlayerStats>(out playerStats))
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

    public async void Damage(int damageAmount)
    {
        Health += damageAmount;

        if (damageAmount < 0)
        {
            _renderer.color = hitColor;

            await Task.Delay(250);

            _renderer.color = normalColor;
        }

        if (Health > _maxHealth)
            Health = _maxHealth;

        if (Health <= 0)
            Death();
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }
}
