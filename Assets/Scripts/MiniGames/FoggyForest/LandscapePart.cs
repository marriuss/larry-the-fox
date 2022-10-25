using UnityEngine;

public class LandscapePart : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _landscapePartLeft;
    [SerializeField] private Transform _landscapePartRight;

    public void Initialize(Path pathPrefab, LandscapeLayout prefab1, LandscapeLayout prefab2)
    {
        if (_path != null)
            Instantiate(pathPrefab, _path.position, Quaternion.identity, _path);

        GenerateLandscapePart(prefab1, _landscapePartLeft);
        GenerateLandscapePart(prefab2, _landscapePartRight);
    }

    private void GenerateLandscapePart(LandscapeLayout prefab, Transform parent)
    {
        if (parent != null)
        {
            LandscapeLayout layout = Instantiate(prefab, parent.position, Quaternion.identity, parent);
            layout.RotateRandomly();
        }
    }
}