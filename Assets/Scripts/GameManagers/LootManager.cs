using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class LootManager : MonoSingleton<LootManager>
{
    [SerializeField]
    GameObject[] _droppableItemPool;

    public void GetRandomItem(Vector3 spawnPosition)
    {
        int whichItem = Random.Range(0, _droppableItemPool.Length);

        switch (whichItem)
        {
            //heart
            case 0:
                DropHeart(spawnPosition);
                break;

            //gold
            case 1:
                DropGold(spawnPosition);
                break;

            //mana
            case 2:
                DropMana(spawnPosition);
                break;

            //magic knives
            case 3:
                DropMagicKnives(spawnPosition);
                break;
        }
    }

    public void DropHeart(Vector3 spawnPosition)
    {
        GameObject newHeart = HeartDropPool.Instance.GetObject();
        newHeart.transform.position = spawnPosition;
    }

    public void DropGold(Vector3 spawnPosition)
    {
        GameObject newGold = GoldDropPool.Instance.GetObject();
        newGold.transform.position = spawnPosition;
    }

    public void DropMana(Vector3 spawnPosition)
    {
        if (!Player.Instance.playerProgress.hasMagicGlove)
        {
            DropGold(spawnPosition);
        }
    }

    public void DropMagicKnives(Vector3 spawnPosition)
    {
        if (!Player.Instance.playerProgress.hasMagicKnifePouch)
        {
            DropGold(spawnPosition);
        }
    }
}
