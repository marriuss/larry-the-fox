using UnityEngine;

public class LandscapeLayout : MonoBehaviour
{
    [SerializeField] private float _rotationAngle;

    private const float Quaters = 4;

    public void RotateRandomly()
    {
        float randomAngle = Random.Range(0, Quaters);
        transform.rotation = Quaternion.Euler(0f, _rotationAngle * randomAngle, 0f);
    }
}
