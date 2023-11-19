using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.Interfaces;

public class Breakable : MonoBehaviour, iDamagable<int>
{
    [SerializeField]
    int _maxHealth;

    public float Health { get; set; }

    private void Start()
    {
        Health = _maxHealth;
    }

    public void Damage(int damageAmount)
    {

    }

    public void Death()
    {

    }

    public void Break()
    {

    }
}
