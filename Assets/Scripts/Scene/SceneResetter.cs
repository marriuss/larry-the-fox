using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneResetter : MonoBehaviour
{
    private List<IResetable> _resetableObjects;

    private void Start()
    {
        _resetableObjects = FindObjectsOfType<MonoBehaviour>().OfType<IResetable>().ToList();
    }

    public void Reset()
    {
        foreach (IResetable resetableObject in _resetableObjects)
            resetableObject.ResetState();
    }
}
