using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchedCutscene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (collision.gameObject.TryGetComponent<Player>(out player))
        {
            GameManager.Instance.returningPlayer = true;

            Destroy(gameObject);
        }
    }
}
