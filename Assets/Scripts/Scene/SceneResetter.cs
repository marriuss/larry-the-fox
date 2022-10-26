using System.Collections.Generic;
using UnityEngine;

public class SceneResetter : MonoBehaviour
{
    private static List<ResetableMonoBehaviour> resetableObjects;

    private void Awake()
    {
        resetableObjects = new List<ResetableMonoBehaviour>();
    }

    public static void AddObject(ResetableMonoBehaviour resetableObject)
    {
        resetableObjects.Add(resetableObject);
    }

    public static void ResetScene()
    {
        foreach (ResetableMonoBehaviour resetableObject in resetableObjects)
            resetableObject.ResetState();
    }
}
