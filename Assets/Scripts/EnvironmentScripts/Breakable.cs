using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.Interfaces;

public class Breakable : MonoBehaviour, iDamagable<int>
{
    public bool playerBroke { get; set; }

    [SerializeField]
    int _maxHealth;

    public float Health { get; set; }

    Loot _loot;

    private void Start()
    {
        _loot = GetComponent<Loot>();
    }

    private void OnEnable()
    {
        Health = _maxHealth;
    }

    public void Damage(int damageAmount)
    {
        Health += damageAmount;

        if (Health <= 0)
            Death();
    }

    public void Death()
    {
        Break();
    }

    public void Break()
    {
        gameObject.SetActive(false);
        _loot.LootChance();
    }
}
