using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothZoom : MonoBehaviour
{
    [SerializeField]
    private float zoomMaxValue = 20f;
    [SerializeField]
    private float zoomMinValue = 10f;
    [SerializeField]
    private float zoomSpeed = 0.0125f;
    private Camera camera;
    void Awake()
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

    private void GetReferences()
    {
        camera = Camera.main;
    }


    private void ZoomIn()
    {
        camera.orthographicSize -= zoomSpeed * Time.deltaTime;
        if(camera.orthographicSize <= zoomMinValue)
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
}
