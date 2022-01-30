using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private FlockAgent agentPrefab;

    [SerializeField]
    private FlockBehaviour flockBehaviour;

    [SerializeField, Range(10, 500)] 
    private int startingCount = 250;

    [Range(1f, 100f), SerializeField] 
    private float driveFactor = 10f;

    [Range(1f, 100f), SerializeField] 
    private float maxSpeed = 5f;

    [Range(1f, 10f), SerializeField] 
    private float neighbourRadius = 1.5f;

    [Range(0f, 1f), SerializeField] 
    private float avoidanceRadiusMultiplier = 0.5f;

    [Range(0f, 10f), SerializeField] 
    private float obstacleRadius = 4f;

    [SerializeField]
    private Transform[] spawnPoints;

    #endregion

    #region Private Fields

    private readonly List<FlockAgent> flockAgents = new List<FlockAgent>();
    private float squareMaxSpeed;
    private float squareNeighbourRadius;

    #endregion

    #region Constants

    private const float AgentDensity = 0.08f;

    #endregion

    #region Public Properties

    public float ObstacleRadius => obstacleRadius;

    public float SquareAvoidanceRadius { get; private set; }

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        SquareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (var i = 0; i < startingCount; i++)
        {
            int random = Random.Range(0, spawnPoints.Length);
            var newAgent = Instantiate(agentPrefab, spawnPoints[random].position, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);

            newAgent.name = "Agent " + i;
            newAgent.InitializeFlock(this);
            flockAgents.Add(newAgent);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (var agent in flockAgents)
        {
            if (agent == null)
            {
                DeleteDestroyedAgent(agent);

                return;
            }

            var context = GetNearbyObjects(agent);
            var move = flockBehaviour.CalculateMove(agent, context, this);
            move *= driveFactor;

            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agent.Move(move);
        }
    }

    #endregion

    #region Private Methods

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        var context = new List<Transform>();

        var contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);

        foreach (var collider in contextColliders)
        {
            if (collider != agent.AgentCollider)
            {
                context.Add(collider.transform);
            }
        }

        return context;
    }

    private void DeleteDestroyedAgent(FlockAgent destroyedAgent)
    {
        flockAgents.Remove(destroyedAgent);
    }

    #endregion
}