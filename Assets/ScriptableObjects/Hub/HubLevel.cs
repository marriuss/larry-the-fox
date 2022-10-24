using UnityEngine;
using IJunior.TypedScenes;

[CreateAssetMenu(fileName ="Hub", menuName ="Levels/Create/Hub")]
public class HubLevel : Level
{
    public override void Load()
    {
        Hub.Load();
    }
}
