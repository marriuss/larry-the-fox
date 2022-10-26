using UnityEngine;

public class Fog : ResetableMonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _scale;

    public override void ResetState()
    {
        transform.localPosition = new Vector3(0, 0, _distance);
        transform.localScale = new Vector3(_scale, _scale, 0);
    }
}
