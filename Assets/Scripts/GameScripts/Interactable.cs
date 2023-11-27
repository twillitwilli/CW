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
        bed
    }

    public InteractableType interactableType;

    public int indexValue;

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

    public void Interact()
    {
        switch (interactableType)
        {
            case InteractableType.NPC:

                GetComponent<NPC>().Talk();

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

                Debug.Log("Sleeping");

                Player.Instance.playerStats.RestedStatRefill();

                GameManager.Instance.saveLocation = indexValue;

                SaveManager.Instance.SaveData(playerLoadPosition);

                break;
        }
    }

    private void OpenChest()
    {
        _animator.Play("ChestOpening");

        if (!GameManager.Instance.randomizerMode)
            ChestLogicManager.Instance.SpawnObject(_intValue, transform.position, _parentObject);

        else
            ChestLogicManager.Instance.ProgressionLogic(_intValue, transform.position, _parentObject);
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
