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

    bool _isRunning;

    public bool lockMovement { private get; set; }

    public float cooldownTimer { get; set; }

    [SerializeField]
    GameObject tempEffect;

    private void Update()
    {
        Movement();

        if (!CooldownDone(false, 0))
        {
            // Running cooldown for blink
        }
    }

    public void Movement()
    {
        if (Mathf.Abs(_player.movement.y) < 0.5f && Mathf.Abs(_player.movement.x) < 0.5f)
            DisableRunning();


        if (!lockMovement)
        {
            float xMovement = transform.position.x + (_playerStats.playerSpeed * _player.movement.x * Time.deltaTime);
            float yMovement = transform.position.y + (_playerStats.playerSpeed * _player.movement.y * Time.deltaTime);
            transform.position = new Vector3(xMovement, yMovement, 0);

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
            tempEffect.SetActive(true);
            tempEffect.transform.position = transform.position;

            _playerStats.iFrame = true;

            float xDirection = transform.position.x + (2.5f * _player.movement.x);
            float yDirection = transform.position.y + (2.5f * _player.movement.y);
            transform.position = new Vector3(xDirection, yDirection, 0);

            CooldownDone(true, 3);

            await Task.Delay(500);

            _playerStats.iFrame = false;

            await Task.Delay(2);

            tempEffect.SetActive(false);
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
