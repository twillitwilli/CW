using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class MagicUI : MonoSingleton<MagicUI>
{
    public void Start()
    {
        if (!Player.Instance.playerProgress.hasMagicGlove)
            gameObject.SetActive(false);
    }

    public void UpdateMagicDisplay()
    {
        Debug.Log("not implemented");
    }
}
