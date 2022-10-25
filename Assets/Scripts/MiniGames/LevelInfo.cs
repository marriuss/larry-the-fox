using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private MiniGameLevel _level;

    public MiniGameLevel Level => _level;
    public string Description => _level.Description;
}
