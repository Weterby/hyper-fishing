using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementConfiguration movementConfiguration;
    [SerializeField]
    private Rigidbody2D playerRigidbody;

    private float verticalAxisInput;
    private float horizontalAxisInput;
    private Vector2 directionToMove;


    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        GetMoveInput();
        GetRotateInput();
        if (!IsAnyMoveInput())
        {
            return;
        }
        DesignateDirection();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }

    private bool IsAnyMoveInput()
    {
        return verticalAxisInput >= float.Epsilon;
    }

    private void GetMoveInput()
    {
        verticalAxisInput = Input.GetAxisRaw("Vertical");
    }

    private void GetRotateInput()
    {
        horizontalAxisInput = Input.GetAxisRaw("Horizontal");
    }

    private void DesignateDirection()
    {
        Vector2 newDirection = new Vector2(0,verticalAxisInput).normalized;
        directionToMove = transform.TransformDirection(newDirection).normalized;
    }

    private void ApplyMovement()
    {
        if (IsAnyMoveInput())
        {
            movementConfiguration.Accelerate();
        }
        else
        {
            movementConfiguration.Decelerate();
        }

        playerRigidbody.velocity = directionToMove * movementConfiguration.CurrentSpeed;
    }

    private void ApplyRotation()
    {
        movementConfiguration.Rotate(-horizontalAxisInput);

        transform.Rotate(transform.forward, movementConfiguration.CurrentAngle);
    }

    private void GetReferences()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
}
