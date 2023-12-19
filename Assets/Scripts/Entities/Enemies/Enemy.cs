using UnityEngine;

public class Enemy : Entities
{

    public override void Destroy()
    {
        if (_currentHp <= 0)
        {
            Destroy(this);
        }
    }

    public virtual void EnemyStart(int maxHp, float speed)
    {
        _maxHp = maxHp;
        _speed = speed;
    }

    public virtual void Attack() { }
    public virtual void FollowPlayer() { }
    public virtual void Patrol() { }
}
