using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGameButton : MonoBehaviour
{ 
    [SerializeField]
    GameObject
        _saveFileSelector,
        _createNewFileSave;

    [SerializeField]
    int _saveFile;

    [SerializeField]
    TMP_Text _text;

    bool _isNewGameFile;

    int
        _maxHealth,
        _gold;

    public void CreateLoadGame()
    {
        GameManager.Instance.saveFile = _saveFile;

        if (_isNewGameFile)
        {
            _createNewFileSave.SetActive(true);


            _saveFileSelector.SetActive(false);
        }

        else
            SaveManager.Instance.LoadData(_saveFile);
    }

    public void UpdateButton(SaveData loadedData, bool isNewGame)
    {
        _isNewGameFile = isNewGame;

        if (isNewGame)
            _text.text = "New Game";

        else
        {
            _text.text = loadedData.playerName;
            _maxHealth = loadedData.maxHealth;
            _gold = loadedData.currentGold;
        }
    }
}
