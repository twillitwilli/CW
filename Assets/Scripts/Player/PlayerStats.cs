using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using QTArts.Interfaces;

public class PlayerStats : MonoBehaviour, iDamagable<int>
{
    [SerializeField]
    SpriteRenderer _spriteRenderer;

    [SerializeField]
    HealthUI _healthUI;

    [SerializeField]
    Color
        _normalPlayerColor,
        _playerHitColor;

    public bool isDead { get; set; }
    public float Health { get; set; }
    public float maxHealth { get; set; }
    public bool iFrame { get; set; }

    public float playerSpeed { get; set; }

    public int attackDamage { get; set; }

    void Start()
    {
        DefaultStats();
    }

    public void DefaultStats()
    {
        maxHealth = 3;
        Health = maxHealth;

        playerSpeed = 8;

        attackDamage = 1;
    }

    public async void Damage(int damageAmount)
    {
        if (damageAmount > 0)
        {
            if (!iFrame)
            {
                _spriteRenderer.color = _playerHitColor;
                iFrame = true;

                Health -= damageAmount;
                Health = CheckStatLimit(Health, 0, maxHealth);

                if (Health <= 0)
                    Death();

                await Task.Delay(500);
                _spriteRenderer.color = _normalPlayerColor;
                iFrame = false;
            }
        }

        else
        {
            Health += damageAmount;
            Health = CheckStatLimit(Health, 0, maxHealth);
        }

        _healthUI.AdjustHealthDisplay();
    }

    public void Death()
    {
        isDead = true;
        gameObject.SetActive(false);
    }

    private float CheckStatLimit(
        float currentValue,
        float minLimit,
        float maxLimit)
    {
        if (currentValue < minLimit)
            return minLimit;

        else if (currentValue > maxLimit)
            return maxLimit;

        else
            return currentValue;
    }

    public void AdjustPlayerSpeed(float adjustmentValue)
    {
        playerSpeed += adjustmentValue;
        playerSpeed = CheckStatLimit(playerSpeed, 1, 20);
    }
}
