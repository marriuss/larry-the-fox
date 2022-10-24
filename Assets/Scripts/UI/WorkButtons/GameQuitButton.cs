using UnityEngine;

public class GameQuitButton : WorkButton
{
    protected override void OnButtonClick()
    {
        Application.Quit();
    }
}
