using UnityEngine;

public class SceneLoadButton : WorkButton
{
    private Level _level;

    public void Initialize(Level level)
    {
        _level = level;
    }

    protected override void OnButtonClick()
    {
        _level.Load();
    }
}
