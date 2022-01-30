using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : FilteredFlockBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private float agentSmoothTime = 0.5f;

    #endregion

    #region Private Fields

    private Vector2 currentVelocity;

    #endregion

    #region Public Methods

    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = contextFilter == null ? context : contextFilter.Filter(flockAgent, context);

        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector2) item.position;
        }

        cohesionMove /= context.Count;

        cohesionMove -= (Vector2) flockAgent.transform.position;
        cohesionMove = Vector2.SmoothDamp(flockAgent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);

        return cohesionMove;
    }

    #endregion
}