using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionItem : MonoBehaviour
{
    public enum ItemType
    {
        magicGlove,
        magicKnifePouch,
        fireCrystal,
        ghostStaff,
        bookOfTruth,
        gravityCrystal,
        portalCrystal,
        magicHourglass
    }

    public ItemType typeOfItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (collision.gameObject.TryGetComponent<Player>(out player))
        {
            switch (typeOfItem)
            {
                case ItemType.magicGlove:

                    player.playerProgress.hasMagicGlove = true;

                    MagicUI.Instance.gameObject.SetActive(true);

                    break;

                case ItemType.magicKnifePouch:

                    player.playerProgress.hasMagicKnifePouch = true;

                    break;

                case ItemType.fireCrystal:

                    player.playerProgress.hasFireCrystal = true;

                    break;

                case ItemType.ghostStaff:

                    player.playerProgress.hasGhostStaff = true;

                    break;

                case ItemType.bookOfTruth:

                    player.playerProgress.hasBookOfTruth = true;

                    break;

                case ItemType.gravityCrystal:

                    player.playerProgress.hasGravityCrystal = true;

                    break;

                case ItemType.portalCrystal:

                    player.playerProgress.hasPortalCrystal = true;

                    break;

                case ItemType.magicHourglass:

                    player.playerProgress.hasMagicHourglass = true;

                    break;
            }
        }
    }
}
