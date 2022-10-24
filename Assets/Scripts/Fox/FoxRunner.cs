using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Movement))]
public class FoxRunner : Fox
{
    private Movement _movement;

    public int Points { get; private set; }

    public event UnityAction Died;
    public event UnityAction GotPoint;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        Points = 0;
        GotPoint?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Obstacle obstacle))
            TakeDamage();

        if (collision.collider.TryGetComponent(out PointTrigger _))
            GetPoint();
    }

    private void TakeDamage()
    {
        Died?.Invoke();
        _movement.enabled = false;
    }

    private void GetPoint()
    {
        Points++;
        GotPoint?.Invoke();
    }
}