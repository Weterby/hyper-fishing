using UnityEngine;

public class EnviroRotation : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Camera playerCamera;

    #endregion

    #region Private Fields

    private Transform objectTransform;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        objectTransform.rotation = playerCamera.transform.rotation;
    }

    #endregion
}