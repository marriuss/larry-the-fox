using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : Menu
{
    [SerializeField] private List<MiniGameLevel> _levels;
    [SerializeField] private LevelView _levelViewTemplate;
    [SerializeField] private GameObject _container;

    protected override void PrepareMenu()
    {
        foreach (MiniGameLevel level in _levels)
            AddLevel(level);
    }

    private void AddLevel(MiniGameLevel level)
    {
        LevelView view = Instantiate(_levelViewTemplate, _container.transform);
        view.Initialize(level);
    }
}
