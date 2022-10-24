using UnityEngine;

public class MenuOpenButton : WorkButton
{
    [SerializeField] private Menu _menu;

    protected override void OnButtonClick()
    {
        _menu.Open();
    }
}
