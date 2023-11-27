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

    public PlayerProgress playerProgress;

    [SerializeField]
    PlayerAttack _playerAttack;

    [SerializeField]
    PlayerInteractionTrigger _playerInteractionTrigger;

    public string playerName { get; set; }

    public Vector2 movement { get; private set; }

    public override void Awake()
    {
        playerName = "TheForgotten";

        base.Awake();

        controls = new PlayerControls();

        // Movement
        controls.PlayerBasicControls.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.PlayerBasicControls.Movement.canceled += ctx => movement = new Vector2(0, 0);
        
        controls.PlayerBasicControls.Run.performed += ctx => playerMovement.RunToggle();
        controls.PlayerBasicControls.Blink.performed += ctx => playerMovement.Blink();

        // Attacking
        controls.PlayerBasicControls.BasicAttack.performed += ctx => _playerAttack.Attack();
        controls.PlayerBasicControls.UseItem.performed += ctx => _playerAttack.UseItem();

        // Interaction
        controls.PlayerBasicControls.Interact.performed += ctx => _playerInteractionTrigger.Interact();
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
