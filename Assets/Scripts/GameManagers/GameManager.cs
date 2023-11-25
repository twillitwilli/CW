using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class GameManager : MonoSingleton<GameManager>
{
    Player _player;
    public bool returningPlayer { get; set; }

    private void Start()
    {
        _player = Player.Instance;

        if (!returningPlayer)
        {
            _player.transform.position = new Vector3(2.83f, -0.37f, 0);

            _player.playerStats.Health = 1;
            _player.playerStats.UpdateHealth();
        }
            
    }
}
