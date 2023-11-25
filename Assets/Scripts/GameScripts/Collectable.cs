using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum CollectableType
    {
        heart,
        gold,
        mana,
        magicKnife
    }

    public CollectableType itemType;

    public int itemValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (collision.gameObject.TryGetComponent<Player>(out player))
        {
            PlayerStats playerStats = player.playerStats;

            switch (itemType)
            {
                case CollectableType.heart:

                    playerStats.Damage(itemValue);

                    break;

                case CollectableType.gold:

                    playerStats.AdjustGold(itemValue);

                    break;

                case CollectableType.mana:

                    playerStats.AdjustMana(itemValue);

                    break;

                case CollectableType.magicKnife:

                    playerStats.AdjustMagicKnives(itemValue);

                    break;
            }

            gameObject.SetActive(false);
        }
    }
}
