using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class MovementTransition : Transition
{
    private IMovable _movement;

    private void Awake()
    {
        _movement = GetComponent<IMovable>();
    }

    private void Update()
    {
        if (_movement.IsMoving)
            InvokeTransition();
    }
}
