using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using QTArts.Interfaces;

public class PlayerMovement : MonoBehaviour, iCooldownable
{
    [SerializeField]
    PlayerStats _playerStats;

    [SerializeField]
    PlayerFacingDirection _facingDirection;

    Vector2 _currentMovement;
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

    public void Move(Vector2 movement)
    {
        _currentMovement = movement;
    }

    public void Movement()
    {
        if (Mathf.Abs(_currentMovement.y) < 0.5f && Mathf.Abs(_currentMovement.x) < 0.5f)
        {
            _currentMovement = new Vector2(0, 0);
            DisableRunning();
        }
            

        if (!lockMovement)
        {
            float xMovement = transform.position.x + (_playerStats.playerSpeed * _currentMovement.x * Time.deltaTime);
            float yMovement = transform.position.y + (_playerStats.playerSpeed * _currentMovement.y * Time.deltaTime);
            transform.position = new Vector3(xMovement, yMovement, 0);

            //transform.Translate(movement);
            _facingDirection.FacingDirection(_currentMovement);
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

            float xDirection = transform.position.x + (5 * _currentMovement.x);
            float yDirection = transform.position.y + (5 * _currentMovement.y);
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
