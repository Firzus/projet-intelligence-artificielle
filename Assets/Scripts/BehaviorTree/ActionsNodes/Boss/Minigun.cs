using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ActionNode
{
    [SerializeField] private ShootBullet shoot;
    [SerializeField] private GameObject bullet;
    [HideInInspector] private GameObject _target;
    [HideInInspector] private GameObject _enemy;
    [HideInInspector] private Transform _enemyTransform;


    protected override void OnStart()
    {
        _target = GameObject.FindWithTag("Player");
        _enemy = agent.gameObject;
        _enemyTransform = _enemy.transform;
        shoot = agent.gameObject.GetComponentInChildren<ShootBullet>();
    }
    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(_enemyTransform.position, _target.transform.position);

        if (dist <= agent.fovRange) 
        {
            shoot.HandGunShooting(bullet);
            return State.Success;
        }
        else if (dist >= agent.fovRange)
        {
            return State.Failure;
        }
        return State.Running;
        
    }
}
