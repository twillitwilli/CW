using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFileSelector : MonoBehaviour
{
    [SerializeField]
    LoadGameButton[] _gameSaveFile;

    void Start()
    {
        GameManager.Instance.menuOpened = true;

        CheckSaveFileStatus();
    }

    public void CheckSaveFileStatus()
    {
        for (int i = 0; i < _gameSaveFile.Length; i++)
        {
            string fileName = Application.persistentDataPath + "/" + "PlayerData" + (i + 1);

            if (File.Exists(fileName))
            {
                SaveData loadedData = BinarySaveSystem.LoadData(i + 1);

                _gameSaveFile[i].UpdateButton(loadedData, false);
            }

            else
                _gameSaveFile[i].UpdateButton(null, true);
        }
    }
}
