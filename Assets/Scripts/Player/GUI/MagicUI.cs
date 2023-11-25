using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUI : MonoBehaviour
{
    public void Start()
    {
        if (!Player.Instance.playerProgress.hasMagic)
            gameObject.SetActive(false);
    }

    public void UpdateMagicDisplay()
    {
        Debug.Log("not implemented");
    }
}
