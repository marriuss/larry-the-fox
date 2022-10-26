using UnityEngine;

[RequireComponent(typeof(Fox))]
public class StateMachine : ResetableMonoBehaviour
{
    [SerializeField] private State _firstState;

    private Fox _targetFox;
    private State _currentState;

    private void Awake()
    {
        _targetFox = GetComponent<Fox>();
    }

    public override void ResetState()
    {
        ExitCurrentState();
        EnterState(_firstState);
    }

    private void EnterState(State state)
    {
        _currentState = state;

        if (_currentState != null)
        {
            _currentState.Enter(_targetFox);
            _currentState.TransitionNeed += OnTransitionNeed;
        }
    }

    private void ExitCurrentState()
    {
        if (_currentState != null)
        {
            _currentState.Exit();
            _currentState.TransitionNeed -= OnTransitionNeed;
        }
    }

    private void OnTransitionNeed(State state)
    {
        ExitCurrentState();
        EnterState(state);
    }
}