using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [Range(0, 100)]
    public int lootChance;

    public void LootChance()
    {
        int randomNum = Random.Range(0, 100);

        if (lootChance >= randomNum)
            DropLoot();
    }

    private void DropLoot()
    {
        Debug.Log("Got Loot!");

        LootManager.Instance.GetRandomItem(transform.position);
    }
}
