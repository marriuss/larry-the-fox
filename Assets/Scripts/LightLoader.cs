using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightLoader : MonoBehaviour
{
    [SerializeField] private Quaternion _startRotation;
    [SerializeField] private float _anglePerSecond;

    private void Start()
    {
        transform.rotation = _startRotation;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _anglePerSecond * Time.deltaTime);
    }
}
