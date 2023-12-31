using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerNode : ActionNode
{
    [HideInInspector] private GameObject _target;
    [HideInInspector] private GameObject _enemy;
    [HideInInspector] private Transform _enemyTransform;

    protected override void OnStart()
    {
        _target = GameObject.FindWithTag("Player");
        _enemy = agent.gameObject;
        _enemyTransform = _enemy.transform;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector3.Distance(_enemyTransform.position, _target.transform.position);

        if (dist >= agent.FovRange)
        {
            _enemyTransform.position =Vector2.MoveTowards(
            _enemyTransform.position, 
            _target.transform.position, 
            agent.Speed * Time.deltaTime);

            _enemy.gameObject.GetComponent<Boss>().LookDirection(_target.GetComponent<EntityState>());
            //Debug.Log($"Moving from {_enemyTransform.position} to {_target.transform.position}");

            return State.Success;
        }
        else if (dist <= agent.FovRange) 
        { 
            return State.Failure;
        }
        return State.Running;
    }
}
