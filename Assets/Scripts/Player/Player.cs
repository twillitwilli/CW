using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using QTArts.AbstractClasses;

public class Player : MonoSingleton<Player>
{
    public PlayerControls controls;

    [SerializeField]
    PlayerMovement _playerMovement;

    public PlayerStats playerStats;

    [SerializeField]
    PlayerAttack _playerAttack;

    public override void Awake()
    {
        base.Awake();

        controls = new PlayerControls();

        // Movement
        controls.PlayerBasicControls.Movement.performed += ctx => _playerMovement.Move(ctx.ReadValue<Vector2>());
        controls.PlayerBasicControls.Run.performed += ctx => _playerMovement.RunToggle();
        controls.PlayerBasicControls.Blink.performed += ctx => _playerMovement.Blink();

        //Attacking
        controls.PlayerBasicControls.BasicAttack.performed += ctx => _playerAttack.Attack();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
