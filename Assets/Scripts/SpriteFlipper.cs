using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlipper : MonoBehaviour, IResetable
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        _spriteRenderer.flipX = false;
    }

    public void FlipX(bool flip)
    {
        _spriteRenderer.flipX = flip;
    }
    
    public void FlipY(bool flip)
    {
        _spriteRenderer.flipY = flip;
    }
}
