using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using QTArts.AbstractClasses;

public class Player : MonoSingleton<Player>
{
    public PlayerControls controls;

    public PlayerMovement playerMovement;

    public PlayerStats playerStats;

    [SerializeField]
    PlayerAttack _playerAttack;

    public Vector2 movement { get; private set; }

    public override void Awake()
    {
        base.Awake();

        controls = new PlayerControls();

        // Movement
        controls.PlayerBasicControls.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.PlayerBasicControls.Movement.canceled += ctx => movement = new Vector2(0, 0);
        
        controls.PlayerBasicControls.Run.performed += ctx => playerMovement.RunToggle();
        controls.PlayerBasicControls.Blink.performed += ctx => playerMovement.Blink();

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
