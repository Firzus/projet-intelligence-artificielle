using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicBullet : Enemy
{

    void Start()
    {
        _hp = 10;
        _speed = 1.0f;
        AttackRange = gameObject.GetComponentInChildren<EnemyAttackRange>();
    }

    void Update() 
    {
        Attack();
        FollowPlayer();
        Death();
    }


    public override void Attack()
    {
        if (AttackRange._isInRange && AttackRange._playerIn)
        {
            // Basic Attack
        }

        if (AttackRange._isInRange && AttackRange._playerOut) 
        { 
            // Range Attack
        }

        if (!AttackRange._isInRange)
        {
            // Close up
        }
    }

    public override void FollowPlayer()
    {
        if (AttackRange._isInRange && AttackRange._playerOut)
        {
            // Follow the player
        }
    }

    void Death()
    {
        Destroy();
    }
}