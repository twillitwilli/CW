using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class ChestLogicManager : MonoSingleton<ChestLogicManager>
{
    [SerializeField]
    GameObject[] _chestItems;

    public bool[] chestObtained;

    private void Start()
    {
        chestObtained = new bool[_chestItems.Length];
    }

    // For Randomizer Mode Only
    public void ProgressionLogic(int whichObject, Vector3 spawnPos, Transform parentObj)
    {

    }

    public void SpawnObject(int whichObject, Vector3 spawnPos, Transform parentObj)
    {
        GameObject newObject = Instantiate(_chestItems[whichObject], spawnPos, transform.rotation);
        newObject.transform.SetParent(parentObj);
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
}
