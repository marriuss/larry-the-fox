using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class IdleTransition : Transition
{
    private IMovable _movement;

    private void Awake()
    {
        _movement = GetComponent<IMovable>();
    }

    private void Update()
    {
        if (_movement.IsMoving == false)
            InvokeTransition();
    }
}
