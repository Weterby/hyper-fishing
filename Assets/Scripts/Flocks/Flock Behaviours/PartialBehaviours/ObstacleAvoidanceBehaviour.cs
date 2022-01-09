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
        RaycastHit hit;
        if (Physics.Raycast(flockAgent.transform.position, flockAgent.transform.forward, out hit, flock.ObstacleRadius, contextFilter.layerMask))
        {
            Debug.Log("dfdfd");
            obstacleAvoidanceMove = FindBestObstacleAvoidDirection(flockAgent, flock);
        }

        return obstacleAvoidanceMove;
    }

   private Vector2 FindBestObstacleAvoidDirection(FlockAgent flockAgent, Flock flock)
   {
        float maxDistance = int.MinValue;
        Vector2 selectedDirection = Vector2.zero;
        for(int i = 0; i<flockAgent.DirectionsToCheck.Length; i++)
        {
            RaycastHit hit;
            Vector2 currentDirection = flockAgent.transform.TransformDirection(flockAgent.DirectionsToCheck[i].normalized);
            if (Physics.Raycast(flockAgent.transform.position, currentDirection,out hit, flock.ObstacleRadius, contextFilter.layerMask))
            {
                float currentDistance = (hit.point - flockAgent.transform.position).sqrMagnitude;
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
                Debug.Log(selectedDirection.normalized);
                return selectedDirection.normalized;
            }
        }
        Debug.Log(selectedDirection.normalized);
        return selectedDirection.normalized;
    }
}
