using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D), typeof(SwapSprite))]
public class PlayerMove : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string UP = "Up";
    private const string DOWN = "Down";
    private const string RIGHT = "Right";
    private const string LEFT = "Left";

    [SerializeField] private SwapSprite _swapSprite;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;

    private Vector2 _direction;
    
    private void Start()
    {
        _swapSprite = GetComponent<SwapSprite>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = new Vector2();
    }
    
    private void Update()
    {
#if PC
        _direction.x = Input.GetAxis(HORIZONTAL);
        _direction.y = Input.GetAxis(VERTICAL);
#endif

#if UNITY_ANDROID
        SetDirection(ref _direction);        
#endif

        CorrectlyOfMovement();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.fixedDeltaTime);        
    }

    private void CorrectlyOfMovement()
    {
        if (_direction.x > 0)
        {
            _swapSprite.SetSprite(DirectionSprite.Front);
        }
        if (_direction.x < 0)
        {
            _swapSprite.SetSprite(DirectionSprite.Back);
        }
        if (_direction.y > 0)
        {
            _swapSprite.SetSprite(DirectionSprite.Up);
        }
        if (_direction.y < 0)
        {
            _swapSprite.SetSprite(DirectionSprite.Down);
        }
    }

    private void SetDirection(ref Vector2 coordinate)
    {
        if (CrossPlatformInputManager.GetButtonDown(RIGHT))
        {
            coordinate.x = 1;
        }
        if (CrossPlatformInputManager.GetButtonDown(LEFT))
        {
            coordinate.x = -1;
        }
        if (CrossPlatformInputManager.GetButtonDown(UP))
        {
            coordinate.y = 1;
        }
        if (CrossPlatformInputManager.GetButtonDown(DOWN))
        {
            coordinate.y = -1;
        }

        if (CrossPlatformInputManager.GetButtonUp(RIGHT))
        {
            coordinate.x = 0;
        }
        if (CrossPlatformInputManager.GetButtonUp(LEFT))
        {
            coordinate.x = 0;
        }
        if (CrossPlatformInputManager.GetButtonUp(UP))
        {
            coordinate.y = 0;
        }
        if (CrossPlatformInputManager.GetButtonUp(DOWN))
        {
            coordinate.y = 0;
        }
    }
}
