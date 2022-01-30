using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private FlockBehaviour[] flockBehaviours;
    [SerializeField]
    private float[] behaviourWeights;

    #endregion

    #region Public Properties

    public FlockBehaviour[] FlockBehaviours { get => flockBehaviours; set => flockBehaviours = value; }
    public float[] BehaviourWeights { get => behaviourWeights; set => behaviourWeights = value; }

    #endregion

    #region Public Methods

    public override Vector2 CalculateMove(FlockAgent flockAgent, List<Transform> context, Flock flock)
    {
        if (behaviourWeights.Length != flockBehaviours.Length)
        {
            Debug.LogError($"Data mismatch in {name}", this);

            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < flockBehaviours.Length; i++)
        {
            Vector2 partialMove = flockBehaviours[i].CalculateMove(flockAgent, context, flock) * behaviourWeights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > behaviourWeights[i] * behaviourWeights[i])
                {
                    partialMove.Normalize();
                    partialMove *= behaviourWeights[i];
                }

                move += partialMove;
            }
        }

        return move;
    }

    #endregion
}