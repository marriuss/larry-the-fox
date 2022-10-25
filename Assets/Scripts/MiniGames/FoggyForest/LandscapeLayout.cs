using UnityEngine;

public class LandscapeLayout : MonoBehaviour
{
    [SerializeField] private float _rotationAngle;

    private const int Quaters = 4;

    public void RotateRandomly()
    {
        int randomAngle = Random.Range(0, Quaters);
        transform.Rotate(0f, _rotationAngle * randomAngle, 0f);
    }
}
