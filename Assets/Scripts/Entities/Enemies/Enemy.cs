using UnityEngine;

public class Enemy : Entities
{
    [HideInInspector] public Transform enemyTransform;
    [HideInInspector] public float fovRange = 6f;
    public override void Destroy()
    {
        if (_hp <= 0)
        {
            Destroy(this);
        }
    }

    public virtual void EnemyStart()
    {
        
    }

    public virtual void SetValue(int hp, float speed)
    {
        _hp = hp;
        _speed = speed;
    }

    public virtual void Attack() { }
    public virtual void FollowPlayer() { }
    public virtual void Patrol() { }
}
