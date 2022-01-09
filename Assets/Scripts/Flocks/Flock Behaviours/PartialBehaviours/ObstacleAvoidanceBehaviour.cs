using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Obstacle Avoidance")]
public class ObstacleAvoidanceBehaviour : FilteredFlockBehaviour
{
    //Avoidance behaviour describes how agents move away from others
    //trying to keep constant distance to avoid high density in flock group
    //When there are no neighbours within agent radius, dont modify movement
    private Vector2 currentObstacleAvoidDirection;
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    { 
        Vector2 obstacleAvoidanceMove = Vector2.zero;
        
        if (Physics2D.Raycast(flockAgent.transform.position, flockAgent.transform.forward, flock.ObstacleRadius, contextFilter.layerMask))
        {
            obstacleAvoidanceMove = FindBestObstacleAvoidDirection(flockAgent, flock);
        }

        return obstacleAvoidanceMove;
    }

   private Vector2 FindBestObstacleAvoidDirection(FlockAgent flockAgent, Flock flock)
   {
        if(currentObstacleAvoidDirection != Vector2.zero)
        {
            RaycastHit2D noObstaclesHit = Physics2D.Raycast(flockAgent.transform.position, flockAgent.transform.forward, flock.ObstacleRadius, contextFilter.layerMask);
            if (noObstaclesHit.collider == null)
            {
                return currentObstacleAvoidDirection;
            }
        }

        float maxDistance = int.MinValue;
        Vector2 selectedDirection = Vector2.zero;
        for(int i = 0; i<flockAgent.DirectionsToCheck.Length; i++)
        {
            Vector2 currentDirection = flockAgent.transform.TransformDirection(flockAgent.DirectionsToCheck[i].normalized);

            RaycastHit2D hit = Physics2D.Raycast(flockAgent.transform.position, currentDirection, flock.ObstacleRadius, contextFilter.layerMask);
            if (hit.collider != null)
            {
                float currentDistance = ((Vector3)hit.point - flockAgent.transform.position).sqrMagnitude;
                if(currentDistance > maxDistance)
                {
                    maxDistance = currentDistance;
                    selectedDirection = currentDirection;
                }
            }
            else
            {
                selectedDirection = currentDirection;
                currentObstacleAvoidDirection = currentDirection.normalized;
                return selectedDirection.normalized;
            }
        }
        return selectedDirection.normalized;
    }
}
