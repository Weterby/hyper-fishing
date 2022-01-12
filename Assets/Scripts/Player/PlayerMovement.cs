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
    private Vector2 directionToMove;


    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        GetInput();
        if (!IsAnyInput())
        {
            return;
        }

        DesignateDirection();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private bool IsAnyInput()
    {
        return verticalAxisInput >= float.Epsilon;
    }

    private void GetInput()
    {
        verticalAxisInput = Input.GetAxisRaw("Vertical");
    }

    private void DesignateDirection()
    {
        directionToMove = new Vector2(0,verticalAxisInput);
    }

    private void ApplyMovement()
    {
        if (IsAnyInput())
        {
            movementConfiguration.Accelerate();
        }
        else
        {
            movementConfiguration.Decelerate();
        }

        playerRigidbody.velocity = directionToMove * movementConfiguration.CurrentSpeed;
    }

    private void GetReferences()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
}
