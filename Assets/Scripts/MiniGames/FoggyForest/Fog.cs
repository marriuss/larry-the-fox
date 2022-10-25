using UnityEngine;

public class Fog : MonoBehaviour, IResetable
{
    [SerializeField] private float _distance;
    [SerializeField] private float _scale;

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        transform.localPosition = new Vector3(0, 0, _distance);
        transform.localScale = new Vector3(_scale, _scale, 0);
    }
}
