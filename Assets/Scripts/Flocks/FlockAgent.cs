using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Vector2[] directionsToCheck;

    #endregion

    #region Private Fields

    private Collider2D agentCollider;

    private Flock agentFlock;

    #endregion

    #region Public Properties

    public Collider2D AgentCollider => agentCollider;
    public Flock AgentFlock => agentFlock;

    public Vector2[] DirectionsToCheck => directionsToCheck;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    #endregion

    #region Public Methods

    public void InitializeFlock(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3) velocity * Time.deltaTime;
    }

    #endregion
}