using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerData")]
public class PlayerMovementConfiguration : ScriptableObject
{
    #region Serialized Fields

    [SerializeField]
    private float initialSpeed;
    [SerializeField]
    private float maximumSpeed = 10f;
    [SerializeField]
    private float rotateSpeed = 2f;
    [SerializeField]
    private float accelerationRate = 100f;
    [SerializeField]
    private float decelerationRate = 150f;

    #endregion

    #region Private Fields

    private float currentSpeed;
    private float currentAngle;

    #endregion

    #region Public Properties

    public float MaximumSpeed => maximumSpeed;
    public float RotateSpeed => rotateSpeed;
    public float DecelerationRate => decelerationRate;
    public float AccelerationRate => accelerationRate;
    public float CurrentSpeed => currentSpeed;
    public float CurrentAngle => currentAngle;

    #endregion

    #region Public Methods

    public void Accelerate()
    {
        SetPlayerSpeed(currentSpeed + accelerationRate * Time.deltaTime);
    }

    public void Decelerate()
    {
        SetPlayerSpeed(currentSpeed - decelerationRate * Time.deltaTime);
    }

    public void Rotate(float rotateDirection)
    {
        SetPlayerAngle(rotateDirection * rotateSpeed * Time.deltaTime);
    }

    #endregion

    #region Private Methods

    private void SetPlayerSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp(speed, initialSpeed, maximumSpeed);
    }

    private void SetPlayerAngle(float angle)
    {
        currentAngle = angle;
    }

    #endregion
}