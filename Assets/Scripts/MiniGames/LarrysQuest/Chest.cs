using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Chest : MonoBehaviour, IResetable
{
    [SerializeField, Min(1)] private int _pointsCost;
    [SerializeField] private UnityEvent _playerAppeared;
    [SerializeField] private UnityEvent _playerDisappeared;

    private const float FadingDuration = 0f;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collder;

    public int PointsCost => _pointsCost;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collder = GetComponent<Collider2D>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        _collder.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fox _))
            _playerAppeared?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fox _))
        {
            _collder.enabled = false;
            _playerDisappeared?.Invoke();
        }
    }
}
