using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public enum CutScene
    {
        enteredCotfalVillage
    }

    Player _player;
    Animator _animator;

    [SerializeField]
    GameObject
        _gameOverScreen,
        _onScreenTextDisplayer;

    public CameraEffects cameraEffects;

    private void Start()
    {
        _player = Player.Instance;
        _animator = GetComponent<Animator>();
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

    public void PlayCutScene(CutScene whichScene)
    {
        whichState = CameraState.cutScene;

        _animator.enabled = true;

        switch (whichScene)
        {
            case CutScene.enteredCotfalVillage:

                _animator.Play("EnteredCotfalVillage");

                break;
        }
    }

    public void ReturnToDefaultZoom(string whichArea)
    {
        switch (whichArea)
        {
            case "CotfalVillage":
                break;
        }

        _animator.Play("ZoomBackToNormal");
    }

    public void CameraIdleAnimation()
    {
        _animator.enabled = false;

        whichState = CameraState.followPlayer;

        _player.playerMovement.lockMovement = false;
    }


    public void ZoomedOutCotfalVillage()
    {
        _animator.Play("ZoomedOutCotfalVillage");

        _onScreenTextDisplayer.SetActive(true);
        OnScreenTextDisplayer.Instance.ChangeText(0);
        OnScreenTextDisplayer.Instance.PlayFadeIn();
    }
}
