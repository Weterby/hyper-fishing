using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    #region Constant Fields
    const float AgentDensity = 0.08f;
    #endregion

    #region Serialize Fields
    [SerializeField]
    private FlockAgent agentPrefab;

    [SerializeField]
    private FlockBehaviour flockBehaviour;

    [SerializeField, Range(10, 500)]
    private int startingCount = 250;
    #endregion

    #region Private Fields
    private List<FlockAgent> flockAgents = new List<FlockAgent>();
    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float squareAvoidanceRadius;
    #endregion


    #region Public Fields
    [Range(1f, 100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    public float SquareAvoidanceRadius => squareAvoidanceRadius; 
    #endregion
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent " + i;
            flockAgents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}