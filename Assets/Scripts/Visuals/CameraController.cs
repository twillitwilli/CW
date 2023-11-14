using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class CameraController : MonoSingleton<CameraController>
{
    public enum CameraState
    {
        followPlayer,
        cutScene,
        deathScreen,
        lockCamera
    }

    public CameraState whichState;

    Player _player;

    [SerializeField]
    GameObject _gameOverScreen;

    public CameraEffects cameraEffects;

    private void Start()
    {
        _player = Player.Instance;
    }

    public void Update()
    {
        if (_player.playerStats.isDead)
            whichState = CameraState.deathScreen;

        switch (whichState)
        {
            case CameraState.followPlayer:

                if (_player != null)
                {
                    float posX = _player.transform.position.x;
                    float posY = _player.transform.position.y;

                    transform.position = new Vector3(posX, posY, -10);
                }

                break;

            case CameraState.deathScreen:

                if (!_gameOverScreen.activeSelf)
                    _gameOverScreen.SetActive(true);

                break;
        }
    }
}
