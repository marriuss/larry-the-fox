using UnityEngine;

[RequireComponent(typeof(IMoving))]
public class IdleTransition : Transition
{
    private IMoving _movement;

    private void Awake()
    {
        _movement = GetComponent<IMoving>();
    }

    private void Update()
    {
        if (_movement.IsMoving == false)
            InvokeTransition();
    }
}
