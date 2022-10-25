using UnityEngine;
using DG.Tweening;

public class SpriteFader : MonoBehaviour, IResetable
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private const float FadingDuration = 0.1f;

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
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
