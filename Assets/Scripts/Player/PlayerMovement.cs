using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using QTArts.Interfaces;

public class PlayerMovement : MonoBehaviour, iCooldownable
{
    [SerializeField]
    Player _player;

    [SerializeField]
    PlayerStats _playerStats;

    [SerializeField]
    PlayerFacingDirection _facingDirection;

    bool
        _isRunning,
        _dashReady = true;

    public bool lockMovement { private get; set; }

    public float cooldownTimer { get; set; }

    [SerializeField]
    GameObject
        _dashEffect,
        _dashReadyEffect;

    private async void Update()
    {
        Movement();

        if (CooldownDone(false, 0) && !_dashReady)
        {
            _dashReady = true;

            _dashReadyEffect.SetActive(true);

            await Task.Delay(500);

            _dashReadyEffect.SetActive(false);
        }
    }

    public void Movement()
    {
        if (lockMovement || Mathf.Abs(_player.movement.y) < 0.5f && Mathf.Abs(_player.movement.x) < 0.5f)
            DisableRunning();


        if (!lockMovement)
        {
            float xMovement = _player.transform.position.x + (_playerStats.playerSpeed * _player.movement.x * Time.deltaTime);
            float yMovement = _player.transform.position.y + (_playerStats.playerSpeed * _player.movement.y * Time.deltaTime);
            _player.transform.position = new Vector3(xMovement, yMovement, 0);

            //transform.Translate(movement);
            _facingDirection.FacingDirection(_player.movement);
        }
    }

    public void RunToggle()
    {
        if (!_isRunning)
        {
            _playerStats.AdjustPlayerSpeed(4);
            _isRunning = true;
        }
    }

    void DisableRunning()
    {
        if (_isRunning)
        {
            _playerStats.AdjustPlayerSpeed(-4);
            _isRunning = false;
        }
    }

    public async void Blink()
    {
        if (CooldownDone(false, 0))
        {
            _dashEffect.SetActive(true);
            _playerStats.iFrame = true;

            float xDirection = _player.transform.position.x + (2.5f * _player.movement.x);
            float yDirection = _player.transform.position.y + (2.5f * _player.movement.y);
            _player.transform.position = new Vector3(xDirection, yDirection, 0);

            _dashReady = false;
            CooldownDone(true, 3);

            await Task.Delay(500);

            _playerStats.iFrame = false;
            _dashEffect.SetActive(false);
        }
    }

    public bool CooldownDone(bool setTimer, float cooldownTime)
    {
        if (setTimer)
            cooldownTimer = cooldownTime;

        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        else
            return true;

        return false;
    }
}
