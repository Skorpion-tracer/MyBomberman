using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwapSprite : MonoBehaviour
{
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _backSprite;
    [SerializeField] private Sprite _upSprite;
    [SerializeField] private Sprite _downSprite;

    [SerializeField] private SpriteRenderer _spriteRenderer;

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
