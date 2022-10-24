using UnityEngine;

public class MenuExitButton : WorkButton
{
    [SerializeField] private Menu _menu;

    protected override void OnButtonClick()
    {
        _menu.Close();
    }
}