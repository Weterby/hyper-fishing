using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private PlayerMovementConfiguration movementConfiguration;

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    #endregion

    #region Private Fields

    private Vector2 directionToMove;
    private float horizontalAxisInput;

    private float verticalAxisInput;

    #endregion

    #region Unity Callbacks

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

    #endregion

    #region Private Methods

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
        var newDirection = new Vector2(0, verticalAxisInput).normalized;
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

    #endregion
}