using UnityEngine;

public abstract class ResetableMonoBehaviour : MonoBehaviour, IResetable
{
    private void Start()
    {
        SceneResetter.AddResetableObject(this);
        ResetState();
    }

    public abstract void ResetState();
}
