using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SwapSpriteThreeState), typeof(AIPath), typeof(AIDestinationSetter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private AIDestinationSetter _aIDestination;
    [SerializeField] private float _durationOfDirty = 3.0f;
    [SerializeField] private SwapSpriteThreeState _swapSprite;
    private float _distanceToPlayer = 5;

    public EnemyState State { get; private set; }

    private void Start()
    {
        _aiPath = GetComponent<AIPath>();
        _swapSprite = GetComponent<SwapSpriteThreeState>();
        _aIDestination = GetComponent<AIDestinationSetter>();
        _aIDestination.target = FindObjectOfType<PlayerMove>().transform;
    }

    public void ChangeStateEnemy(EnemyState state)
    {
        State = state;
    }

    private void Update()
    {
        ControlState();
        SetState();
    }

    private void ControlState()
    {
        switch (State)
        {
            case EnemyState.Dirty:
                _swapSprite.SetSprite(GetDirection(), State);
                float maxSpeedTemp = _aiPath.maxSpeed;
                _aiPath.maxSpeed = 0;
                StartCoroutine(FromDirtyToCalm());
                StopCoroutine(FromDirtyToCalm());
                _aiPath.maxSpeed = maxSpeedTemp;                
                break;
            default: 
                _swapSprite.SetSprite(GetDirection(), State);
                break;
        }
    }

    private IEnumerator FromDirtyToCalm()
    {
        yield return new WaitForSeconds(_durationOfDirty);
        State = EnemyState.Calm;
    }

    private DirectionSprite GetDirection()
    {
        if (_aiPath.steeringTarget.x > 0) return DirectionSprite.Front;
        if (_aiPath.steeringTarget.x < 0) return DirectionSprite.Back;
        if (_aiPath.steeringTarget.y > 0) return DirectionSprite.Up;
        if (_aiPath.steeringTarget.y < 0) return DirectionSprite.Down;
        return DirectionSprite.Front;
    }

    private void SetState()
    {
        if (State == EnemyState.Calm)
        {
            if (Vector2.Distance(gameObject.transform.position, _aIDestination.target.position) < _distanceToPlayer)
            {
                State = EnemyState.Angry;
            }            
        }       
        if (State == EnemyState.Angry)
        {
            if (Vector2.Distance(gameObject.transform.position, _aIDestination.target.position) > _distanceToPlayer)
            {
                State = EnemyState.Calm;
            }
        }
    }
}

