using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private FoxRunner _player;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.GotPoint += OnPointsChanged;
    }

    private void OnDisable()
    {
        _player.GotPoint -= OnPointsChanged;
    }

    private void OnPointsChanged()
    {
        _text.text = _player.Points.ToString();
    }
}
