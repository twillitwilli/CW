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

    [SerializeField]
    BoxCollider2D _collider;

    [SerializeField]
    GameObject _ghostEffect;
    public bool ghostForm { get; set; }
    public GameObject playerMimic { get; set; }

    public override void Awake()
    {
        base.Awake();

        controls = new PlayerControls();

        // Movement
        controls.ControllerSupport.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.ControllerSupport.Movement.canceled += ctx => movement = new Vector2(0, 0);
        
        controls.ControllerSupport.Run.performed += ctx => playerMovement.RunToggle();
        controls.ControllerSupport.Blink.performed += ctx => playerMovement.Blink();

        // Attacking
        controls.ControllerSupport.BasicAttack.performed += ctx => _playerAttack.Attack();

        // Item Controls
        controls.ControllerSupport.UseItem.performed += ctx => _playerAttack.itemController.UseItem();
        controls.ControllerSupport.NextItem.performed += ctx => _playerAttack.NextItem();
        controls.ControllerSupport.PreviousItem.performed += ctx => _playerAttack.PreviousItem();

        // Interaction
        controls.ControllerSupport.Interact.performed += ctx => _playerInteractionTrigger.Interact();

        // Inventory Screen
        controls.ControllerSupport.Menu.performed += ctx => InventoryScreen.Instance.OpenCloseInventory();
        controls.ControllerSupport.NextItem.performed += ctx => InventoryScreen.Instance.NextPage();
        controls.ControllerSupport.PreviousItem.performed += ctx => InventoryScreen.Instance.PreviousPage();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (ghostForm && Vector3.Distance(transform.position, playerMimic.transform.position) > 10)
            GhostForm(false);
    }

    public void GhostForm(bool ghost)
    {
        if (ghostForm)
        {
            transform.position = playerMimic.transform.position;
            Destroy(playerMimic);
            GetComponent<SpriteRenderer>().enabled = true;
        }

        else
            GetComponent<SpriteRenderer>().enabled = false;

        _collider.isTrigger = ghost;
        _ghostEffect.SetActive(ghost);
        ghostForm = ghost;
    }
}
