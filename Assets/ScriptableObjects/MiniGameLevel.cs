using UnityEngine;

public abstract class MiniGameLevel : Level
{
    [SerializeField] private string _title;
    [SerializeField] private Sprite _icon;

    public string Title => _title;
    public Sprite Icon => _icon;
}
