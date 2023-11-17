using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractableType
    {
        NPC,
        chest,
        jar,
        door,
        sign
    }

    public InteractableType interactableType;

    public void Interact()
    {
        switch (interactableType)
        {
            case InteractableType.NPC:

                GetComponent<NPC>().Talk();

                break;

            case InteractableType.chest:
                break;

            case InteractableType.jar:
                break;

            case InteractableType.door:
                break;

            case InteractableType.sign:
                break;
        }
    }
}
