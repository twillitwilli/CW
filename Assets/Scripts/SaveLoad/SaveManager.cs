using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class SaveManager : MonoSingleton<SaveManager>
{
    Player _player;
    PlayerStats _playerStats;
    PlayerProgress _playerProgress;

    [SerializeField]
    bool _testLoading;

    public void Start()
    {
        _player = Player.Instance;
        _playerStats = _player.playerStats;
        _playerProgress = _player.playerProgress;
    }

    private void Update()
    {
        if (_testLoading)
        {
            LoadData(0);

            _testLoading = false;
        }
    }

    public void SaveData(Vector3 savePosition)
    {
        Debug.Log("Saving Game");

        BinarySaveSystem.SaveData(CreateSaveData(savePosition), _player.saveFile);
    }

    public void LoadData(int saveFile)
    {
        Debug.Log("Loading Game");

        SaveData loadedData = BinarySaveSystem.LoadData(saveFile);

        if (loadedData != null)
            UpdateLoadedData(loadedData);
    }

    public void DeleteData(int saveFile)
    {
        BinarySaveSystem.DeleteFileSave(saveFile);
    }

    private SaveData CreateSaveData(Vector3 savePosition)
    {
        SaveData newData = new SaveData();

        newData.playerName = _player.playerName;
        newData.saveFile = _player.saveFile;

        newData.playerPosition = new float[3];
        newData.playerPosition[0] = savePosition.x;
        newData.playerPosition[1] = savePosition.y;
        newData.playerPosition[2] = savePosition.z;

        // Player Stats
        newData.maxHealth = _playerStats.maxHealth;
        newData.currentGold = _playerStats.currentGold;
        newData.maxGold = _playerStats.maxGold;
        newData.maxMana = _playerStats.maxMana;
        newData.currentMagicKnives = _playerStats.currentMagicKnives;
        newData.maxMagicKnives = _playerStats.maxMagicKnives;

        // Player Progression
        newData.hasSpear = _playerProgress.hasSpear;
        newData.hasGuard = _playerProgress.hasGuard;
        newData.hasMagicKnifePouch = _playerProgress.hasMagicKnifePouch;
        newData.hasFireCrystal = _playerProgress.hasFireCrystal;
        newData.hasGhostStaff = _playerProgress.hasGhostStaff;
        newData.hasBookOfTruth = _playerProgress.hasBookOfTruth;
        newData.hasGravityCrystal = _playerProgress.hasGravityCrystal;
        newData.hasPortalCrystal = _playerProgress.hasPortalCrystal;
        newData.hasMagicHourglass = _playerProgress.hasMagicHourglass;
        newData.hasMagic = _playerProgress.hasMagic;

        return newData;
    }

    private void UpdateLoadedData(SaveData loadedData)
    {
        _player.playerName = loadedData.playerName;
        _player.saveFile = loadedData.saveFile;

        Vector3 playerLoadPosition = new Vector3(loadedData.playerPosition[0], loadedData.playerPosition[1], loadedData.playerPosition[2]);
        _player.transform.position = playerLoadPosition;

        // Player Stats
        _playerStats.maxHealth = loadedData.maxHealth;
        _playerStats.currentGold = loadedData.currentGold;
        _playerStats.maxGold = loadedData.maxGold;
        _playerStats.maxMana = loadedData.maxMana;
        _playerStats.currentMagicKnives = loadedData.currentMagicKnives;
        _playerStats.maxMagicKnives = loadedData.maxMagicKnives;
        _playerStats.RestedStatRefill();
        _playerStats.UpdateGUI();

        // Player Progression
        _playerProgress.hasSpear = loadedData.hasSpear;
        _playerProgress.hasGuard = loadedData.hasGuard;
        _playerProgress.hasMagicKnifePouch = loadedData.hasMagicKnifePouch;
        _playerProgress.hasFireCrystal = loadedData.hasFireCrystal;
        _playerProgress.hasGhostStaff = loadedData.hasGhostStaff;
        _playerProgress.hasBookOfTruth = loadedData.hasBookOfTruth;
        _playerProgress.hasGravityCrystal = loadedData.hasGravityCrystal;
        _playerProgress.hasPortalCrystal = loadedData.hasPortalCrystal;
        _playerProgress.hasMagicHourglass = loadedData.hasMagicHourglass;
        _playerProgress.hasMagic = loadedData.hasMagic;
    }
}
