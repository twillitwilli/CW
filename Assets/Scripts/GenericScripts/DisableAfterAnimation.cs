using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterAnimation : MonoBehaviour
{
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
