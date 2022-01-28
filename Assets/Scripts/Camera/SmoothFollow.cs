using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 10f;

    private void FixedUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);

        transform.position = smoothedPosition + offset;
        transform.rotation = Quaternion.Lerp(transform.rotation,playerPosition.rotation, rotateSpeed * Time.deltaTime);
    }
}