using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInRange : ActionNode
{
    [SerializeField] private ShootBullet shoot;
    [SerializeField] private GameObject bullet;
    [HideInInspector] private GameObject _target;
    private float fovRange;
    protected override void OnStart()
    {
        shoot = agent.gameObject.GetComponentInChildren<ShootBullet>();
        _target = GameObject.FindWithTag("Player");
        fovRange = agent.fovRange;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(agent.transform.position, _target.transform.position);

        if (dist <= fovRange)
        {
            shoot.HandGunShooting(bullet);
            Debug.Log($"Within Range. {dist}");
            return State.Success;
        }

        else
        {
            return State.Failure;
        }
    }
}
