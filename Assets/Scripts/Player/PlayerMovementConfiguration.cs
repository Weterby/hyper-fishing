using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerData")]
public class PlayerMovementConfiguration : ScriptableObject
{
    [SerializeField]
    private float initialSpeed = 0f;
    [SerializeField]
    private float maximumSpeed=10f;
    [SerializeField]
    private float rotateSpeed=2f;
    [SerializeField]
    private float accelerationRate = 100f;
    [SerializeField]
    private float decelerationRate = 150f;

    private float currentSpeed;
    private float currentAngle;

    public float MaximumSpeed => maximumSpeed;
    public float RotateSpeed => rotateSpeed;
    public float DecelerationRate => decelerationRate;
    public float AccelerationRate => accelerationRate;
    public float CurrentSpeed => currentSpeed;
    public float CurrentAngle => currentAngle;

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

    private void SetPlayerSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp(speed, initialSpeed, maximumSpeed);
    }


    private void SetPlayerAngle(float angle)
    {
        currentAngle = angle;
    }
}
