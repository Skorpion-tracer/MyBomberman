using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SwapSprite))]
public class PlayerMove : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

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
        _direction.x = Input.GetAxis(HORIZONTAL);
        _direction.y = Input.GetAxis(VERTICAL);

        CheckDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.fixedDeltaTime);
        
    }

    private void CheckDirection()
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
}
