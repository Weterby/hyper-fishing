using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Transform playerPosition;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float rotateSpeed = 10f;

    #endregion

    #region Unity Callbacks

    private void FixedUpdate()
    {
        var smoothedPosition = Vector3.Lerp(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);

        transform.position = smoothedPosition + offset;
        transform.rotation = Quaternion.Lerp(transform.rotation, playerPosition.rotation, rotateSpeed * Time.deltaTime);
    }

    #endregion
}