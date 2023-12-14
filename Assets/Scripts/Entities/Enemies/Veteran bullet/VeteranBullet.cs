using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeteranBullet : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        _hp = 50;
        _speed = 2;
        AttackRange = gameObject.GetComponentInChildren<EnemyAttackRange>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        // Follow the player
    }

    void Death()
    {
        Destroy();
    }
}
