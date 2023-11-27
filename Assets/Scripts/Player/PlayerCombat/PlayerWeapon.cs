using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public Sprite itemSpite;
    public string itemName;
    public bool canEquip;

    public GameObject[] weaponAttacks;
}
