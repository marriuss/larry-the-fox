using UnityEngine;

[RequireComponent(typeof(IMoving))]
public class MovementTransition : Transition
{
    private IMoving _movement;

    private void Awake()
    {
        _movement = GetComponent<IMoving>();
    }

    private void Update()
    {
        if (_movement.IsMoving)
            InvokeTransition();
    }
}
