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
    GoldUI _goldUI;

    [SerializeField]
    MagicUI _magicUI;

    [SerializeField]
    Color
        _normalPlayerColor,
        _playerHitColor;

    public bool isDead { get; set; }
    public float Health { get; set; }
    public int maxHealth { get; set; }
    public bool iFrame { get; set; }

    public float playerSpeed { get; set; }
    public int attackDamage { get; set; }

    public int currentGold {get; set;}
    public int maxGold { get; set; }
    public float currentMana { get; set; }
    public int maxMana { get; set; }
    public int currentMagicKnives { get; set; }
    public int maxMagicKnives { get; set; }

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

        maxGold = 250;
    }

    public void RestedStatRefill()
    {
        Health = maxHealth;
        currentMana = maxMana;
    }

    public async void Damage(int damageAmount)
    {
        if (damageAmount < 0)
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

        UpdateHealth();
    }

    public void UpdateHealth()
    {
        _healthUI.AdjustHealthDisplay(Mathf.RoundToInt(Health), maxHealth);
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

    public void AdjustGold(int adjustmentValue)
    {
        currentGold += adjustmentValue;

        currentGold = Mathf.RoundToInt(CheckStatLimit(currentGold, 0, maxGold));

        _goldUI.UpdateGoldDisplay(currentGold);
    }

    public void AdjustMana(int adjustmentValue)
    {
        currentMana += adjustmentValue;

        currentMana = Mathf.RoundToInt(CheckStatLimit(currentMana, 0, maxMana));

        _magicUI.UpdateMagicDisplay();
    }

    public void AdjustMagicKnives(int adjustmentValue)
    {
        currentMagicKnives += adjustmentValue;

        currentMagicKnives = Mathf.RoundToInt(CheckStatLimit(currentMagicKnives, 0, maxMagicKnives));
    }

    public void UpdateGUI()
    {
        _healthUI.AdjustHealthDisplay(Mathf.RoundToInt(Health), maxHealth);
        _goldUI.UpdateGoldDisplay(currentGold);
        _magicUI.UpdateMagicDisplay();
    }
}
