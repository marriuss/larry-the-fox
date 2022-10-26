using UnityEngine;

[RequireComponent(typeof(RunningMovement))]
public class FoxRunner : Fox
{
    private RunningMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<RunningMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Obstacle _))
        {
            LoseGame();
            _movement.enabled = false;
        }

        if (collision.collider.TryGetComponent(out PointTrigger _))
            GetPoints(1);
    }

    protected override void ResetAdditionalStats()
    {
        _movement.enabled = true;
    }
}