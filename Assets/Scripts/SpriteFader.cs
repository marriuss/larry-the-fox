using UnityEngine;
using DG.Tweening;

public class SpriteFader : ResetableMonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private const float FadingDuration = 0.1f;

    public override void ResetState()
    {
        Appear();
    }

    public void Appear()
    {
        _spriteRenderer.DOFade(1, 0);
    }

    public void Disappear()
    {
        _spriteRenderer.DOFade(0, FadingDuration);
    }
}
