using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSaveFile : MonoBehaviour
{
    [SerializeField]
    SaveFileSelector _saveFileSelector;

    [SerializeField]
    int _saveFile;

    public void DeleteSave()
    {
        BinarySaveSystem.DeleteFileSave(_saveFile);

        _saveFileSelector.CheckSaveFileStatus();
    }
}
