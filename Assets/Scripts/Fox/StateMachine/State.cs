using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] private string _stateAnimation;
    
    private Animator _animator;

    public event UnityAction<State> TransitionNeed;

    protected Fox Fox { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        enabled = false;
    }

    public void Enter(Fox fox)
    {
        if (enabled)
            return;

        Fox = fox;
        enabled = true;

        foreach (Transition transition in _transitions)
        {
            transition.Initialize(fox);
            transition.TransitionConditionsMet += OnTransitionConditionsMet;
            transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == false)
            return;

        foreach (Transition transition in _transitions)
        {
            transition.enabled = false;
            transition.TransitionConditionsMet -= OnTransitionConditionsMet;
        }

        enabled = false;
    }

    protected void PlayStateAnimation()
    {   
        _animator.Play(_stateAnimation);
    }

    protected void StopStateAnimation()
    {
        _animator.StopPlayback();
    }

    private void OnTransitionConditionsMet(State state)
    {
        TransitionNeed?.Invoke(state);
    }
}