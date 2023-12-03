using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DevModeOnly : MonoBehaviour
{
    public async void Start()
    {
        await Task.Delay(250);

        if (!GameManager.Instance.developerModeActive)
            Destroy(gameObject);
    }
}
