using UnityEngine;

public class Enemy : Entities
{

    public override void Destroy()
    {
        if (_hp <= 0)
        {
            Destroy(this);
        }
    }

    public virtual void EnemyStart(int hp, float speed)
    {
        _hp = hp;
        _speed = speed;
    }

    public virtual void Attack() { }
    public virtual void FollowPlayer() { }
    public virtual void Patrol() { }
}
