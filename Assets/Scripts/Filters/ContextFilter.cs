using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContextFilter : ScriptableObject
{
    [SerializeField]
    public LayerMask layerMask;
    public abstract List<Transform> Filter(FlockAgent agent, List<Transform> originalContext);
}
