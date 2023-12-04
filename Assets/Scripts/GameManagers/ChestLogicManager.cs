using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using QTArts.AbstractClasses;

public class ChestLogicManager : MonoSingleton<ChestLogicManager>
{
    PlayerStats _playerStats;
    PlayerProgress _playerProgress;

    public RandomizableItem[] obtainableItems;

    [SerializeField]
    int[] _numberOfChestsInLevel;

    [HideInInspector]
    public bool[] chestObtained;


    private void Start()
    {
        _playerStats = Player.Instance.playerStats;
        _playerProgress = Player.Instance.playerProgress;

        chestObtained = new bool[obtainableItems.Length];
    }

    public void CheckChestStatus()
    {
        for (int i = 0; i < chestObtained.Length; i++)
        {
            if (chestObtained[i])
            {
                for (int i2 = 0; i2 < SceneController.Instance.obtainableChests.Length; i++)
                {
                    if (i == SceneController.Instance.obtainableChests[i2].GetComponent<Interactable>().indexValue)
                    {
                        Destroy(SceneController.Instance.obtainableChests[i2]);
                    }
                }
            }
        }
    }

    public void RandomizeItems()
    {
        List<RandomizableItem> shuffledList = obtainableItems.OrderBy(x => Random.value).ToList();
    }

    public void GetItem(int whichItem)
    {
        for (int i = 0; i < obtainableItems.Length; i++)
        {
            if (obtainableItems[i].itemIndex == whichItem)
            {
                obtainableItems[i].obtainedItem = true;

                GiveItem(obtainableItems[i]);

                return;
            }
        }
    }

    public void GiveItem(RandomizableItem item)
    {
        switch (item.itemName)
        {
            case "Spear":

                _playerProgress.hasSpear = true;
                _playerProgress.ObtainedWeapon(PlayerAttack.EquippedWeapon.spear);

                break;

            case "Scythe":

                _playerProgress.hasScythe = true;
                _playerProgress.ObtainedWeapon(PlayerAttack.EquippedWeapon.scythe);

                break;

            case "The Forgotten Scythe":

                _playerProgress.hasTheForgottenScythe = true;
                _playerProgress.ObtainedWeapon(PlayerAttack.EquippedWeapon.forgottenScythe);

                break;

            case "Magic Glove":

                _playerProgress.hasMagicGlove = true;

                break;

            case "Magic Knife Pouch":

                if (!_playerProgress.hasMagicKnifePouch)
                {
                    _playerProgress.hasMagicKnifePouch = true;
                    _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.magicKnifePouch);
                }

                else
                    _playerStats.maxMagicKnives += 15;

                break;

            case "Fire Crystal":

                _playerProgress.hasFireCrystal = true;
                _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.fireCrystal);

                break;

            case "Ghost Staff":

                _playerProgress.hasGhostStaff = true;
                _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.ghostStaff);

                break;

            case "Book Of Truth":

                _playerProgress.hasBookOfTruth = true;
                _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.bookOfTruth);

                break;

            case "Gravity Crystal":

                _playerProgress.hasGravityCrystal = true;
                _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.gravityCrystal);

                break;

            case "Portal Crystal":

                _playerProgress.hasPortalCrystal = true;
                _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.portalCrystal);

                break;

            case "Magic Hour Glass":

                _playerProgress.hasMagicHourglass = true;
                _playerProgress.ObtainedItem(PlayerAttack.EquippedItem.magicHourGlass);

                break;

            case "1 Gold":
                _playerStats.AdjustGold(1);
                break;

            case "10 Gold":
                _playerStats.AdjustGold(10);
                break;

            case "20 Gold":
                _playerStats.AdjustGold(20);
                break;

            case "30 Gold":
                _playerStats.AdjustGold(30);
                break;

            case "40 Gold":
                _playerStats.AdjustGold(40);
                break;

            case "50 Gold":
                _playerStats.AdjustGold(50);
                break;

            case "75 Gold":
                _playerStats.AdjustGold(75);
                break;

            case "100 Gold":
                _playerStats.AdjustGold(100);
                break;

            case "250 Gold":
                _playerStats.AdjustGold(250);
                break;

            case "500 Gold":
                _playerStats.AdjustGold(500);
                break;

            case "Heart Piece":
                _playerStats.GotHeartPiece();
                break;

            case "Mimic":
                break;
        }

        InventoryScreen.Instance.UpdateItems();
    }
}
