using UnityEngine;

public class Enemy : Entities
{
    public virtual void EnemyStart(int maxHp, float speed)
    {
        _maxHp = maxHp;
        _speed = speed;
    }
}
