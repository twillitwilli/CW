using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractableType
    {
        NPC,
        chest,
        jar,
        door,
        sign,
        bed,
        shopItem
    }

    public InteractableType interactableType;

    public int indexValue;

    [SerializeField]
    bool _interactableBool;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    int _intValue;

    [SerializeField]
    Transform _parentObject;

    public Vector3 playerLoadPosition;

    BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void SetPrice(int priceOfItem)
    {
        _intValue = priceOfItem;
    }

    public void Interact()
    {
        switch (interactableType)
        {
            case InteractableType.NPC:

                if (!_interactableBool)
                    GetComponent<NPC>().Talk();

                else
                {
                    if (Player.Instance.playerStats.currentGold > _intValue)
                    {
                        GetComponent<NPC>().BuyItem();

                        Player.Instance.playerStats.AdjustGold(-_intValue);
                    }
                        

                    else
                        Debug.Log("Not Enough Money!");
                }

                break;

            case InteractableType.chest:

                _collider.enabled = false;
                OpenChest();

                break;

            case InteractableType.jar:
                break;

            case InteractableType.door:
                break;

            case InteractableType.sign:
                break;

            case InteractableType.bed:

                CameraController.Instance.cameraEffects.CameraCloseOpen();

                Debug.Log("Sleeping");

                GameManager.Instance.saveLocation = indexValue;

                SaveManager.Instance.SaveData(playerLoadPosition);

                SaveManager.Instance.LoadData(GameManager.Instance.saveFile);

                break;

            case InteractableType.shopItem:

                if (Player.Instance.playerStats.currentGold > _intValue)
                {
                    GetComponent<ShopItem>().BuyItem();

                    Player.Instance.playerStats.AdjustGold(-_intValue);
                }

                else
                    Debug.Log("Not Enough Money!");

                break;
        }
    }

    private void OpenChest()
    {
        _animator.Play("ChestOpening");

        ChestLogicManager.Instance.GetItem(indexValue);
    }

    public async void ChestOpened()
    {
        _animator.Play("Opened");

        await Task.Delay(3000);

        _animator.Play("FadeOut");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
