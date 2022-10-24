using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InAirTransition : Transition
{
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (_movement.IsInAir)
            InvokeTransition();
    }
}
