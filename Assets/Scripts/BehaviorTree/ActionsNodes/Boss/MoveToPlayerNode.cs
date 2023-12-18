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
        if (this._enemyTransform.position != _target.transform.position )
        {
            _enemyTransform.position =Vector3.MoveTowards(
            _enemyTransform.position, 
            _target.transform.position, 
            5f * Time.deltaTime);
            Debug.Log($"Moving from {_enemyTransform.position} to {_target.transform.position}");

            return State.Success;
        }
        return State.Running;
    }
}
