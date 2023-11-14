using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public enum Effects
    {
        quickSceneChangeExpand,
        quickSceneChangeCollapse
    }

    [SerializeField]
    GameObject[] effect;

    public void ChangeCameraEffect(Effects effects)
    {
        switch (effects)
        {
            case Effects.quickSceneChangeExpand:
                effect[0].SetActive(true);
                break;

            case Effects.quickSceneChangeCollapse:
                effect[0].GetComponent<Animator>().Play("Collapse");
                break;
        }
    }
}
