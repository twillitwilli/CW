using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class SaveManager : MonoSingleton<SaveManager>
{
    Player _player;
    PlayerStats _playerStats;
    PlayerProgress _playerProgress;

    public void Start()
    {
        _player = Player.Instance;
        _playerStats = _player.playerStats;
        _playerProgress = _player.playerProgress;
    }

    public void SaveData(Vector3 savePosition)
    {
        Debug.Log("Saving Game");

        GameManager.Instance.returningPlayer = true;

        BinarySaveSystem.SaveData(CreateSaveData(savePosition), GameManager.Instance.saveFile);

        Debug.Log("Save Complete");
    }

    public void LoadData(int saveFile)
    {
        Debug.Log("Loading Game");

        SaveData loadedData = BinarySaveSystem.LoadData(saveFile);

        if (loadedData != null)
            UpdateLoadedData(loadedData);

        else
        {
            Debug.Log("New Game Started");

            GameManager.Instance.returningPlayer = false;
            GameManager.Instance.LoadSaveArea();
        }
    }

    private SaveData CreateSaveData(Vector3 savePosition)
    {
        SaveData newData = new SaveData();

        newData.playerName = _player.playerName;

        newData.playerPosition = new float[3];
        newData.playerPosition[0] = savePosition.x;
        newData.playerPosition[1] = savePosition.y;
        newData.playerPosition[2] = savePosition.z;

        newData.saveFile = GameManager.Instance.saveFile;
        newData.saveLocation = GameManager.Instance.saveLocation;
        newData.returningPlayer = GameManager.Instance.returningPlayer;
        newData.randomizerMode = GameManager.Instance.randomizerMode;

        newData.chestsObtained = new bool[ChestLogicManager.Instance.chestObtained.Length];
        newData.chestsObtained = ChestLogicManager.Instance.chestObtained;

        newData.itemsObtained = new bool[ChestLogicManager.Instance.obtainableItems.Length];

        for (int i = 0; i < ChestLogicManager.Instance.obtainableItems.Length; i++)
        {
            newData.itemsObtained[i] = ChestLogicManager.Instance.obtainableItems[i].obtainedItem;
        }

        // Player Stats
        newData.maxHealth = _playerStats.maxHealth;
        newData.currentHeartPiece = _playerStats.currentHeartPiece;
        newData.currentGold = _playerStats.currentGold;
        newData.maxGold = _playerStats.maxGold;
        newData.maxMana = _playerStats.maxMana;
        newData.currentMagicKnives = _playerStats.currentMagicKnives;
        newData.maxMagicKnives = _playerStats.maxMagicKnives;

        // Player Progression
        newData.hasSpear = _playerProgress.hasSpear;
        newData.hasScythe = _playerProgress.hasScythe;
        newData.hasTheForgottenScythe = _playerProgress.hasTheForgottenScythe;
        newData.hasMagicGlove = _playerProgress.hasMagicGlove;
        newData.hasMagicKnifePouch = _playerProgress.hasMagicKnifePouch;
        newData.hasFireCrystal = _playerProgress.hasFireCrystal;
        newData.hasGhostStaff = _playerProgress.hasGhostStaff;
        newData.hasBookOfTruth = _playerProgress.hasBookOfTruth;
        newData.hasGravityCrystal = _playerProgress.hasGravityCrystal;
        newData.hasPortalCrystal = _playerProgress.hasPortalCrystal;
        newData.hasMagicHourglass = _playerProgress.hasMagicHourglass;

        return newData;
    }


    // Loading for returning player
    private void UpdateLoadedData(SaveData loadedData)
    {
        _player.playerName = loadedData.playerName;

        Vector3 playerLoadPosition = new Vector3(loadedData.playerPosition[0], loadedData.playerPosition[1], loadedData.playerPosition[2]);
        _player.transform.position = playerLoadPosition;

        GameManager.Instance.saveFile = loadedData.saveFile;
        GameManager.Instance.saveLocation = loadedData.saveLocation;
        GameManager.Instance.returningPlayer = true;
        GameManager.Instance.LoadSaveArea();

        ChestLogicManager.Instance.chestObtained = loadedData.chestsObtained;
        ChestLogicManager.Instance.CheckChestStatus();
        GameManager.Instance.randomizerMode = loadedData.randomizerMode;

        for (int i = 0; i < ChestLogicManager.Instance.obtainableItems.Length; i++)
        {
            ChestLogicManager.Instance.obtainableItems[i].obtainedItem = loadedData.itemsObtained[i];
        }

        // Player Stats
        _playerStats.maxHealth = loadedData.maxHealth;
        _playerStats.currentHeartPiece = loadedData.currentHeartPiece;
        _playerStats.currentGold = loadedData.currentGold;
        _playerStats.maxGold = loadedData.maxGold;
        _playerStats.maxMana = loadedData.maxMana;
        _playerStats.currentMagicKnives = loadedData.currentMagicKnives;
        _playerStats.maxMagicKnives = loadedData.maxMagicKnives;
        _playerStats.RestedStatRefill();
        _playerStats.UpdateGUI();

        // Player Progression
        _playerProgress.hasSpear = loadedData.hasSpear;
        _playerProgress.hasScythe = loadedData.hasScythe;
        _playerProgress.hasTheForgottenScythe = loadedData.hasTheForgottenScythe;
        _playerProgress.hasMagicGlove = loadedData.hasMagicGlove;
        _playerProgress.hasMagicKnifePouch = loadedData.hasMagicKnifePouch;
        _playerProgress.hasFireCrystal = loadedData.hasFireCrystal;
        _playerProgress.hasGhostStaff = loadedData.hasGhostStaff;
        _playerProgress.hasBookOfTruth = loadedData.hasBookOfTruth;
        _playerProgress.hasGravityCrystal = loadedData.hasGravityCrystal;
        _playerProgress.hasPortalCrystal = loadedData.hasPortalCrystal;
        _playerProgress.hasMagicHourglass = loadedData.hasMagicHourglass;

        Debug.Log("File Loaded");
    }
}
