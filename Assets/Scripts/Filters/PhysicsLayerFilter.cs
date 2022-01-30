using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Physics Layer")]
public class PhysicsLayerFilter : ContextFilter
{
    #region Public Methods

    public override List<Transform> Filter(FlockAgent agent, List<Transform> originalContext)
    {
        List<Transform> filteredContext = new List<Transform>();

        foreach (Transform item in originalContext)
        {
            if (layerMask == (layerMask | (1 << item.gameObject.layer)))
            {
                filteredContext.Add(item);
            }
        }

        return filteredContext;
    }

    #endregion
}