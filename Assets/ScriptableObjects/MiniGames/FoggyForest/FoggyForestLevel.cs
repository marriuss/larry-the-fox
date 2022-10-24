using UnityEngine;
using IJunior.TypedScenes;

[CreateAssetMenu(fileName ="NewLevel", menuName ="Levels/Create/FoggyForest", order =51)]
public class FoggyForestLevel : MiniGameLevel
{
    public override void Load()
    {
        FoggyForest.Load();
    }
}
