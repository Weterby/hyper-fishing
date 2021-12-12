using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    [SerializeField]
    private FlockBehaviour[] flockBehaviours;
    [SerializeField]
    private float[] behaviourWeights;

    public FlockBehaviour[] FlockBehaviours { get => flockBehaviours; set => flockBehaviours = value; }
    public float[] BehaviourWeights { get => behaviourWeights; set => behaviourWeights = value; }

    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        if(behaviourWeights.Length != flockBehaviours.Length)
        {
            Debug.LogError($"Data mismatch in {name}", this);
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < flockBehaviours.Length; i++)
        {
            Vector2 partialMove = flockBehaviours[i].CalculateMove(flockAgent, context, flock) * behaviourWeights[1];
            
            if(partialMove != Vector2.zero)
            {
                if(partialMove.sqrMagnitude > behaviourWeights[i] * behaviourWeights[i])
                {
                    partialMove.Normalize();
                    partialMove *= behaviourWeights[i];
                }

                move += partialMove;
            }
        }

        return move;
    }
}
