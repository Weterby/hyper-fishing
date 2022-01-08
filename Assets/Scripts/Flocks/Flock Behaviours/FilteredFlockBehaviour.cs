using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FilteredFlockBehaviour : FlockBehaviour
{
    [SerializeField]
    protected ContextFilter contextFilter;
}
