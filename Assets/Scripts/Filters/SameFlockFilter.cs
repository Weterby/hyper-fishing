using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/SameFlock")]
public class SameFlockFilter : ContextFilter
{
    #region Public Methods

    public override List<Transform> Filter(FlockAgent agent, List<Transform> originalContext)
    {
        List<Transform> filteredContext = new List<Transform>();

        foreach (Transform item in originalContext)
        {
            FlockAgent itemAgent = item.GetComponent<FlockAgent>();

            if (itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock)
            {
                filteredContext.Add(item);
            }
        }

        return filteredContext;
    }

    #endregion
}