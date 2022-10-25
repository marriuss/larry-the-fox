using UnityEngine;
using TMPro;

public class HelpMenu : Menu
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private TMP_Text _helpText;

    protected override void PrepareMenu()
    {
        _helpText.text = _levelInfo.Description;
    }
}
