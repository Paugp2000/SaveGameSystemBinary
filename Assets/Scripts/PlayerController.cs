using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rb;


    private bool isGrounded;

    [Header("Input")]
    [SerializeField] InputAction movementAction;


    [Header("Movement")]
    [SerializeField] float horizontalMovementSpeed = 5.0f;
    [SerializeField] float forwardMovementSpeed = 5.0f;
    Vector2 horizontalVelocity;
    float lastHorizontal = 1.0f;

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
        rb.velocity = new Vector3(horizontalVelocity.x, 0, horizontalVelocity.y);
    }

    void OnMovement(InputAction.CallbackContext ctx)
    {
        horizontalVelocity = ctx.ReadValue<Vector2>() * horizontalMovementSpeed;
    }
}