using UnityEngine;

public abstract class ResetableMonoBehaviour : MonoBehaviour, IResetable
{
    private void Start()
    {
        SceneResetter.AddObject(this);
        ResetState();
    }

    public abstract void ResetState();
}
