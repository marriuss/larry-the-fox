using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private SceneLoadButton _sceneLoaderButton;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _titleText;

    public void Initialize(MiniGameLevel level)
    {

        if (_iconImage != null)
            _iconImage.sprite = level.Icon;

        if (_titleText != null)
            _titleText.text = level.Title;

        if (_sceneLoaderButton != null)
            _sceneLoaderButton.Initialize(level);
    }
}