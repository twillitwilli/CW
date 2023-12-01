using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    Collectable.CollectableType replenishableItem;

    [SerializeField]
    bool _replensishableItem;

    [SerializeField]
    int
        _itemIndex,
        _price;

    private void Start()
    {
        GetComponent<Interactable>().SetPrice(_price);
    }

    public void BuyItem()
    {
        if (Player.Instance.playerStats.currentGold > _price)
        {
            Player.Instance.playerStats.AdjustGold(-_price);

            if (!_replensishableItem)
            {
                ChestLogicManager.Instance.GetItem(_itemIndex);

                Destroy(gameObject);
            }
        }
    }
}
