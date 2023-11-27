using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSaveFile : MonoBehaviour
{
    [SerializeField]
    int _saveFile;

    public void DeleteSave()
    {
        SaveManager.Instance.DeleteData(_saveFile);
    }
}
