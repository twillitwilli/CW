using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class GameManager : MonoSingleton<GameManager>
{
    public bool returningPlayer { get; set; }

    private void Start()
    {
        if (!returningPlayer)
            Player.Instance.transform.position = new Vector3(2.83f, -0.37f, 0);
    }
}
