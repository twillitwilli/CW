using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionTrigger : MonoBehaviour
{
    public void Interact()
    {
        Collider2D[] interactableObjects = Physics2D.OverlapCircleAll(transform.position, 0.25f);

        foreach (Collider2D col in interactableObjects)
        {
            Interactable interactable;

            if (col.gameObject.TryGetComponent<Interactable>(out interactable))
                interactable.Interact();
        }
    }
}
