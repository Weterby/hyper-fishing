using System.Collections.Generic;
using UnityEngine;

public class CustomEdgeCollider : MonoBehaviour
{
    #region Private Fields

    private EdgeCollider2D edgeCollider;
    private PolygonCollider2D polygonCollider;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        SwapColliderPoints();
        RemovePreviousCollider();
    }

    #endregion

    #region Private Methods

    private void GetReferences()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();

        if (polygonCollider == null)
        {
            polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    private void SwapColliderPoints()
    {
        var colliderPoints = new List<Vector2>();

        foreach (var point in polygonCollider.points)
        {
            colliderPoints.Add(point);
        }

        colliderPoints.Add(new Vector2(colliderPoints[0].x, colliderPoints[0].y));

        edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.points = colliderPoints.ToArray();
    }

    private void RemovePreviousCollider()
    {
        Destroy(polygonCollider);
    }

    #endregion
}