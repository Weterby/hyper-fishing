using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroRotation : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private Transform objectTransform;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        objectTransform.rotation = playerCamera.transform.rotation;
    }
}
