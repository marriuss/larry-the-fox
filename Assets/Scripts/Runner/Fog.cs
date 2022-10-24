using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _scale;

    private void Awake()
    {
        transform.localPosition = new Vector3(0, 0, _distance);
        transform.localScale = new Vector3(_scale, _scale, 0);
    }
}
