using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnClickMovement : MonoBehaviour, IMoving, IResetable
{
    [SerializeField, Min(0.1f)] private float _speed;
    [SerializeField] private UnityEvent<bool> _xMovementDirectionFlipped;

    private Player _playerInput;
    private Coroutine _movingCoroutine;
    private Camera _camera;
    private PointerEventData _pointerEventData;
    private bool _isMovingLeft;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _playerInput = new Player();
        _pointerEventData = new PointerEventData(EventSystem.current);
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        ResetState();
    }

    private void OnDisable()
    {
        StopMovement();
        _playerInput.Disable();
        _playerInput.LarrysQuest.Click.performed -= ctx => OnMove();
    }

    public void ResetState()
    {
        _playerInput.Enable();
        _playerInput.LarrysQuest.Click.performed += ctx => OnMove();
        _isMovingLeft = false;
    }

    private void OnMove()
    {
        Vector2 clickScreenPosition = _playerInput.LarrysQuest.Move.ReadValue<Vector2>();

        if (CheckIsMovementAvailable(clickScreenPosition))
        {
            Vector2 actionWorldPosition = _camera.ScreenToWorldPoint(clickScreenPosition);
            Move(actionWorldPosition);
        }
    }

    private void StopMovement()
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        IsMoving = false;
    }

    private void Move(Vector2 target)
    {
        StopMovement();
        _movingCoroutine = StartCoroutine(MoveTowards(target));
    }

    private IEnumerator MoveTowards(Vector2 target)
    {
        IsMoving = true;
        Vector3 newPosition = target;

        _isMovingLeft = newPosition.x < transform.position.x;
        InvokeXDirectionFlip();

        while (transform.position != newPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }

        IsMoving = false;
    }

    private bool CheckIsMovementAvailable(Vector2 clickPosition)
    {
        _pointerEventData.position = clickPosition;
        return !EventSystem.current.CheckIsAnyElementPointed(_pointerEventData);
    }

    private void InvokeXDirectionFlip()
    {
        _xMovementDirectionFlipped?.Invoke(_isMovingLeft);
    }
}
