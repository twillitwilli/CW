using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    GameObject _saveFileSelector;

    public void TitleScreenEnded()
    {
        _saveFileSelector.SetActive(true);

        gameObject.SetActive(false);
    }
}
