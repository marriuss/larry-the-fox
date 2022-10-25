using UnityEngine;
using IJunior.TypedScenes;

[CreateAssetMenu(fileName="Larry's Quest", menuName ="Levels/Create/Larry's Quest")]
class LarrysQuestLevel : MiniGameLevel
{
    public override void Load()
    {
        LarrysQuest.Load();
    }
}