using UnityEngine;

[RequireComponent(typeof(OnClickMovement))]
public class FoxQuester : Fox
{
    private OnClickMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<OnClickMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chest chest))
            GetPoints(chest.PointsCost);

        if (collision.TryGetComponent(out Exit _))
            WinGame();

        if (collision.TryGetComponent(out Maze _))
        {
            _movement.enabled = false;
            LoseGame();
        }
    }

    protected override void ResetAdditionalStats()
    {
        _movement.enabled = true;
    }
}