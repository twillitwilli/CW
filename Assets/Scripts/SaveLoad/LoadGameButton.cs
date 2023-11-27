using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGameButton : MonoBehaviour
{
    [SerializeField]
    int _saveFile;

    [SerializeField]
    TMP_Text _text;

    public void CreateLoadGame()
    {
        GameManager.Instance.saveFile = _saveFile;

        SaveManager.Instance.LoadData(_saveFile);
    }

    public void UpdateText(string loadDataName)
    {
        _text.text = loadDataName;
    }
}
