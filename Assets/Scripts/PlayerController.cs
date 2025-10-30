using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rb;
    public GameObject player;
    public Button load;
    public SaveGameClass saveGame;
    public SaveSystemController saveSystem;

    public static PlayerController instance;
    int coins = 0;
    [Header("Input")]
    [SerializeField] InputAction movementAction;


    [Header("Movement")]
    [SerializeField] float horizontalMovementSpeed = 5.0f;
    [SerializeField] float forwardMovementSpeed = 5.0f;
    Vector2 horizontalVelocity;

    float lastHorizontal = 1.0f;

    [Header("Position")]
    [SerializeField] public float positionX;
    [SerializeField] public float positionY;
    [SerializeField] public float positionZ;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movementAction.performed += OnMovement;
        lastHorizontal = 1.0f;
    }
    private void OnEnable()
    {
        movementAction.Enable();
    }
    private void OnDisable()
    {
        movementAction.Disable();
    }

    void Update()
    {
        rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.y);
        positionX = player.transform.position.x;
        positionY = player.transform.position.y;
        positionZ = player.transform.position.z;
        
    }

    void OnMovement(InputAction.CallbackContext ctx)
    {
        horizontalVelocity = ctx.ReadValue<Vector2>() * horizontalMovementSpeed;
    }
    public void changePosition()
    {
        saveGame = saveSystem.loadSavedSystem();
        positionX = saveGame.position[0];
        positionY = saveGame.position[1];
        positionZ = saveGame.position[2];
        Vector3 newPosition = new Vector3(positionX, positionY, positionZ);
        player.transform.position = newPosition;
    }
    public void PickUpCoin()
    {
        coins++;
    }
    public int GetCoins()
    {
        return coins;
    }
}