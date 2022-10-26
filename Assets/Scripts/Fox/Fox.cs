using UnityEngine.Events;

public class Fox : ResetableMonoBehaviour
{
    public event UnityAction Won;
    public event UnityAction Lost;
    public event UnityAction PointsChanged;

    public int Points { get; private set; }

    public override void ResetState()
    {
        Points = 0;
        PointsChanged?.Invoke();
        ResetAdditionalStats();
    }

    protected virtual void ResetAdditionalStats() { }

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