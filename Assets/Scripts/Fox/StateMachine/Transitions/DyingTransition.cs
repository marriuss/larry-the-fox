public class DyingTransition : Transition
{
    private FoxRunner _fox;

    private void OnEnable()
    {
        _fox = Target as FoxRunner;

        if (_fox != null)
            _fox.Died += OnFoxDied;
    }

    private void OnFoxDied()
    {
        _fox.Died -= OnFoxDied;
        InvokeTransition();
    }
}