using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ActionNode
{
    [SerializeField] private ShootBullet shoot;
    [SerializeField] private GameObject bullet;
    

    protected override void OnStart()
    {
        shoot = agent.gameObject.GetComponentInChildren<ShootBullet>();
    }
    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (shoot) 
        {
            shoot.HandGunShooting(bullet);
        }
        
        return State.Success;
    }
}
