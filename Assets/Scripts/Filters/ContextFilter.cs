using System.Collections.Generic;
using UnityEngine;

public abstract class ContextFilter : ScriptableObject
{
    #region Serialized Fields

    [SerializeField]
    public LayerMask layerMask;

    #endregion

    #region Public Methods

    public abstract List<Transform> Filter(FlockAgent agent, List<Transform> originalContext);

    #endregion
}