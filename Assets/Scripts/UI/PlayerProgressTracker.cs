using TMPro;
using UnityEngine;

public class PlayerProgressTracker : MonoBehaviour, IResetable
{
    [SerializeField] private Fox _player;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _gameEndMessage;
    [SerializeField] private TMP_Text _finalScoreMessage;
    [SerializeField] private Menu _gameOverMenu;

    private string _playerPoints => _player.Points.ToString();

    private void OnEnable()
    {
        _player.PointsChanged += OnPointsChanged;
        _player.Won += OnPlayerWon;
        _player.Lost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _player.PointsChanged -= OnPointsChanged;
        _player.Won -= OnPlayerWon;
        _player.Lost -= OnPlayerLost;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        _scoreText.alpha = 1;
    }

    private void OnPlayerWon()
    {
        EndGame("Congratulations!");
    }

    private void OnPlayerLost()
    {
        EndGame("Game over!");
    }

    private void EndGame(string finalMessage)
    {
        _scoreText.alpha = 0;
        _gameEndMessage.text = finalMessage;
        _finalScoreMessage.text = $"Your final score:\n{_playerPoints}";
        _gameOverMenu.Open();
    } 

    private void OnPointsChanged()
    {
        _scoreText.text = _playerPoints;
    }
}
