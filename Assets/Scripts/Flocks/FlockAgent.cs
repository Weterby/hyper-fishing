using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{

    private Collider2D agentCollider;
    public Collider2D AgentCollider => agentCollider;

    private Flock agentFlock;
    public Flock AgentFlock => agentFlock;

    [SerializeField]
    private Vector2[] directionsToCheck;

    public Vector2[] DirectionsToCheck => directionsToCheck;
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void InitializeFlock(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }
}
