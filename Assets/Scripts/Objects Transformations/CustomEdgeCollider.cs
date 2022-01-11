using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEdgeCollider : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    private EdgeCollider2D edgeCollider;
    void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        SwapColliderPoints();
        RemovePreviousCollider();
    }

    private void GetReferences()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();

        if(polygonCollider == null)
        {
            polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    private void SwapColliderPoints()
    {
        List<Vector2> colliderPoints = new List<Vector2>();

        foreach(Vector2 point in polygonCollider.points)
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
}
