using UnityEngine;

public class GameOverMenu : Menu
{
    [SerializeField] private FoxRunner _player;
    [SerializeField] private MiniGameLevel _level;
    [SerializeField] private SceneLoadButton _button;

    private void OnEnable()
    {
        if (_button != null && _level != null)
            _button.Initialize(_level);

        if (_player != null)
            _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        Open();
    }
}
