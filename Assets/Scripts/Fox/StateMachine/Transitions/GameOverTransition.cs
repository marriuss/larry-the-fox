public class GameOverTransition : Transition
{
    private void OnEnable()
    {
        Target.Lost += OnGameOver;
    }

    private void OnGameOver()
    {
        Target.Lost -= OnGameOver;
        InvokeTransition();
    }
}