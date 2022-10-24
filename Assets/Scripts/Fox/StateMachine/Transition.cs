using UnityEngine;
using UnityEngine.Events;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public event UnityAction<State> TransitionConditionsMet;

    protected Fox Target { get; private set; }

    private void Awake()
    {
        enabled = false;
    }

    public void Initialize(Fox target)
    {
        Target = target;
    }

    protected void InvokeTransition()
    {
        TransitionConditionsMet?.Invoke(_targetState);
    }
}