using UnityEngine;
using UnityEngine.Events;

public class Fox : MonoBehaviour, IResetable
{
    public event UnityAction Won;
    public event UnityAction Lost;
    public event UnityAction PointsChanged;

    public int Points { get; private set; }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        Points = 0;
        PointsChanged?.Invoke();
        Reset();
    }

    protected virtual void Reset() { }

    protected void WinGame()
    {
        Won?.Invoke();
    }

    protected void LoseGame()
    {
        Lost?.Invoke();
    }

    protected void GetPoints(int points)
    {
        Points += points;
        PointsChanged?.Invoke();
    }
}