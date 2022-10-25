using UnityEngine;

public abstract class MiniGameLevel : Level
{
    [SerializeField] private string _title;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;

    public string Title => _title;
    public Sprite Icon => _icon;
    public string Description => _description;
}
