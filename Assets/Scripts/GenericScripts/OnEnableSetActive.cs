using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableSetActive : MonoBehaviour
{
    [SerializeField]
    GameObject[]
        enableObjs,
        disabledObjs;

    private void OnEnable()
    {
        if (enableObjs.Length > 0)
        {
            foreach (GameObject obj in enableObjs)
            {
                obj.SetActive(true);
            }
        }

        if (disabledObjs.Length > 0)
        {
            foreach (GameObject obj in disabledObjs)
            {
                obj.SetActive(false);
            }
        }
    }
}
