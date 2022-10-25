using UnityEngine;

[RequireComponent(typeof(RunningMovement))]
public class GroundedMovementTransition : Transition
{
    private RunningMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<RunningMovement>();
    }

    private void Update()
    {
        if (_movement.IsInAir == false)
            InvokeTransition();
    }
}
