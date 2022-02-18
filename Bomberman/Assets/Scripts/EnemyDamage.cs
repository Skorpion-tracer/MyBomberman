using UnityEngine;

public class EnemyDamage : MonoBehaviour, IDamage
{
    [SerializeField] private Enemy _enemy;

    public void Damage()
    {
        _enemy.ChangeStateEnemy(EnemyState.Dirty);
        Debug.Log("DirtyEnemy");
    }
}

