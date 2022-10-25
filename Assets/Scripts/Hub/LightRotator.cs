using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightRotator : MonoBehaviour
{
    [SerializeField] private float _anglePerSecond;
    
    private void Update()
    {
        transform.Rotate(Vector3.up, _anglePerSecond * Time.deltaTime);
    }
}
