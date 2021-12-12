using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FlockBehaviour
{
    //Cohesion behaviour describes how agent position themselves
    //depending on other agents within its radius.
    //When no agents are nearby agent doesnt modify its position.
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        if(context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;
        foreach(Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }

        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)flockAgent.transform.position;
        return cohesionMove;
    }

}
