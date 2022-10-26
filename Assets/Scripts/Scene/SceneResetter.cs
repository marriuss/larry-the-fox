using System.Collections.Generic;
using UnityEngine;

public class SceneResetter : MonoBehaviour
{
    private static SceneResetter instance;

    private List<ResetableMonoBehaviour> resetableObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            resetableObjects = new List<ResetableMonoBehaviour>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void AddResetableObject(ResetableMonoBehaviour resetableObject)
    {
        if (instance != null)
            instance.Add(resetableObject);
    }

    private void Add(ResetableMonoBehaviour resetableObject)
    {
        resetableObjects.Add(resetableObject);
    }

    public static void ResetScene()
    {
        if (instance != null)
        {
            foreach (ResetableMonoBehaviour resetableObject in instance.resetableObjects)
                resetableObject.ResetState();
        }
    }
}
