public class WinTransition : Transition
{
    private void OnEnable()
    {
        Target.Won += OnPlayerWon;
    }

    private void OnPlayerWon()
    {
        Target.Won -= OnPlayerWon;
        InvokeTransition();
    }
}
