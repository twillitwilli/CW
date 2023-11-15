using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class KineticForce : MonoBehaviour
{
    private async void OnEnable()
    {
        await Task.Delay(5000);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 8 * Time.deltaTime);
    }
}
