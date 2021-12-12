using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    [SerializeField]
    private FlockBehaviour[] flockBehaviours;
    [SerializeField]
    private float[] weights;
    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        if(weights.Length != flockBehaviours.Length)
        {
            Debug.LogError($"Data mismatch in {name}", this);
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < flockBehaviours.Length; i++)
        {
            Vector2 partialMove = flockBehaviours[i].CalculateMove(flockAgent, context, flock) * weights[1];
            
            if(partialMove != Vector2.zero)
            {
                if(partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                move += partialMove;
            }
        }

        return move;
    }
}
