using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwapSprite : MonoBehaviour
{
    [Header("Calm State")]
    [SerializeField] protected Sprite _frontSprite;
    [SerializeField] protected Sprite _backSprite;
    [SerializeField] protected Sprite _upSprite;
    [SerializeField] protected Sprite _downSprite;

    [SerializeField] protected SpriteRenderer _spriteRenderer;

    public void SetSprite(DirectionSprite directionSprite)
    {
        switch (directionSprite)
        {
            case DirectionSprite.Front:
                _spriteRenderer.sprite = _frontSprite;
                break;
            case DirectionSprite.Back:
                _spriteRenderer.sprite = _backSprite;
                break;
            case DirectionSprite.Down:
                _spriteRenderer.sprite = _downSprite;
                break;
            case DirectionSprite.Up:
                _spriteRenderer.sprite = _upSprite;
                break;
        }
    }
}
