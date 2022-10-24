using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _gravityModifier;
    [SerializeField, Min(0.1f)] private float _jumpHeight;
    [SerializeField, Min(0.1f)] private float _speed;

    private const float ShellRadius = 0.2f;

    private Player _playerInput;
    private Collider _collider;
    private Rigidbody _rigidbody;
    private float _yMovement;
    private float _groundDistance;
    private bool _isGrounded;

    public bool IsInAir => _isGrounded == false;

    private void Awake()
    {
        _playerInput = new Player();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = false;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Runner.Jump.performed += ctx => OnJump(); 
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Runner.Jump.performed -= ctx => OnJump();
    }

    private void Start()
    {
        _groundDistance = _collider.bounds.extents.y;
        _yMovement = 0;
    }

    private void FixedUpdate()
    {
        float deltaTime = Time.deltaTime;
        _rigidbody.position += _speed * deltaTime * Vector3.right;
        _yMovement += Physics.gravity.y * _gravityModifier * deltaTime;
        float yDeltaPosition = _yMovement * deltaTime;
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundDistance + ShellRadius);

        if (_isGrounded && yDeltaPosition <= 0)
            yDeltaPosition = 0;
        
        _rigidbody.position += Vector3.up * yDeltaPosition;
    }

    private void OnJump()
    {
        if (_isGrounded)
            _yMovement = _jumpHeight;
    }
}