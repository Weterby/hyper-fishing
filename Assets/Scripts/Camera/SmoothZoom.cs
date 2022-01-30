using UnityEngine;

public class SmoothZoom : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private float zoomMaxValue = 20f;
    [SerializeField]
    private float zoomMinValue = 10f;
    [SerializeField]
    private float zoomSpeed = 0.0125f;

    #endregion

    #region Private Fields

    private Camera camera;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GetReferences();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            ZoomOut();
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            ZoomIn();
        }
    }

    #endregion

    #region Private Methods

    private void GetReferences()
    {
        camera = Camera.main;
    }

    private void ZoomIn()
    {
        camera.orthographicSize -= zoomSpeed * Time.deltaTime;

        if (camera.orthographicSize <= zoomMinValue)
        {
            camera.orthographicSize = zoomMinValue;
        }
    }

    private void ZoomOut()
    {
        camera.orthographicSize += zoomSpeed * Time.deltaTime;

        if (camera.orthographicSize >= zoomMaxValue)
        {
            camera.orthographicSize = zoomMaxValue;
        }
    }

    #endregion
}