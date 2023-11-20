using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableSetActive : MonoBehaviour
{
    [SerializeField]
    GameObject[]
    enableObjs,
    disabledObjs;

    private void OnDisable()
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
