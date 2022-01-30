using UnityEngine;

public abstract class FilteredFlockBehaviour : FlockBehaviour
{
    #region Serialized Fields

    [SerializeField]
    protected ContextFilter contextFilter;

    #endregion
}