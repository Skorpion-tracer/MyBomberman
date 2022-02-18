using UnityEngine;


public sealed class SwapSpriteThreeState : SwapSprite
{
    [Header("Angry State")]
    [SerializeField] private Sprite _frontSpriteAngry;
    [SerializeField] private Sprite _backSpriteAngry;
    [SerializeField] private Sprite _upSpriteAngry;
    [SerializeField] private Sprite _downSpriteAngry;

    [Header("Dirty State")]
    [SerializeField] private Sprite _frontSpriteDirty;
    [SerializeField] private Sprite _backSpriteDirty;
    [SerializeField] private Sprite _upSpriteDirty;
    [SerializeField] private Sprite _downSpriteDirty;

    public void SetSprite(DirectionSprite directionSprite, EnemyState enemyState)
    {
        if (enemyState == EnemyState.Calm)
        {
            base.SetSprite(directionSprite);
            return;
        }
        else
        {
            if (enemyState == EnemyState.Angry)
            {
                ChangeSprite(directionSprite, _frontSpriteAngry, _backSpriteAngry, _downSpriteAngry, _upSpriteAngry);
                return;
            }
            else
            {
                ChangeSprite(directionSprite, _frontSpriteDirty, _backSpriteDirty, _downSpriteDirty, _upSpriteDirty);
            }
        }        
    }

    private void ChangeSprite(DirectionSprite directionSprite, params Sprite[] sprites)
    {
        switch (directionSprite)
        {
            case DirectionSprite.Front:
                _spriteRenderer.sprite = sprites[0];
                break;
            case DirectionSprite.Back:
                _spriteRenderer.sprite = sprites[1];
                break;
            case DirectionSprite.Down:
                _spriteRenderer.sprite = sprites[2];
                break;
            case DirectionSprite.Up:
                _spriteRenderer.sprite = sprites[3];
                break;
        }
    }
}

