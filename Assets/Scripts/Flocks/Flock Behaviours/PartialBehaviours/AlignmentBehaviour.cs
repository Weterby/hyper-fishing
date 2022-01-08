using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    //Alignment behaviour describes how agents calculate common direction
    //based on actual direction of agents in flock.
    //When there are no other agents within agent radius, agent keeps moving forward.

    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            return flockAgent.transform.up;
        }
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (contextFilter == null) ? context : contextFilter.Filter(flockAgent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector2)item.transform.up;
        }

        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
