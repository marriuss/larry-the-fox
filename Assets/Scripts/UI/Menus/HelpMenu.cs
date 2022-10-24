using UnityEngine;
using TMPro;

public class HelpMenu : Menu
{
    [SerializeField] private TMP_Text _helpText;

    public void Initialize(string helpText)
    {
        if (_helpText != null)
            _helpText.text = helpText;
    }
}
