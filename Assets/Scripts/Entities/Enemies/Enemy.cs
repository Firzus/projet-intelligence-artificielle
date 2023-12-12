using UnityEngine;

public class Enemy : Entities
{
    public EnemyAttackRange AttackRange;

    public override void Destroy()
    {
        if (_hp <= 0)
        {
            Destroy(this);
        }
    }

    public virtual void Attack() { }
    public virtual void FollowPlayer() { }
    public virtual void Patrol() { }
}
