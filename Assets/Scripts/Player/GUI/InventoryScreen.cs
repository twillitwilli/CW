using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class InventoryScreen : MonoSingleton<InventoryScreen>
{
    public bool inventoryOpen { get; set; }

    int _inventoryPage;

    [SerializeField]
    GameObject _inventory;

    [SerializeField]
    GameObject[] _inventoryPages;

    [SerializeField]
    CheckPlayerProgress[] _itemChecks;

    public void OpenCloseInventory()
    {
        if (!inventoryOpen)
        {
            _inventory.SetActive(true);
            inventoryOpen = true;
        }

        else
        {
            _inventory.SetActive(false);
            inventoryOpen = false;
        }
    }

    public void NextPage()
    {
        if (inventoryOpen)
        {
            _inventoryPage++;

            if (_inventoryPage > 3)
                _inventoryPage = 0;

            ChangeInventoryPage();
        }
    }

    public void PreviousPage()
    {
        if (inventoryOpen)
        {
            _inventoryPage--;

            if (_inventoryPage < 0)
                _inventoryPage = 3;

            ChangeInventoryPage();
        }
    }

    private void ChangeInventoryPage()
    {
        foreach (GameObject obj in _inventoryPages)
        {
            obj.SetActive(false);
        }

        _inventoryPages[_inventoryPage].SetActive(true);
    }

    public void UpdateItems()
    {
        foreach (CheckPlayerProgress check in _itemChecks)
        {
            check.UpdateProgress();
        }
    }
}
