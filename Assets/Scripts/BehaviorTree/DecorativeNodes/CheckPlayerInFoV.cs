using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInFoV : DecorativeNode
{
    private GameObject _target;
    private GameObject _enemy;
    private Transform _enemyTransform;
    private static int _playerLayerMask = 1 << 6;

    protected override void OnStart()
    {
        _enemy = agent.gameObject;
        _enemyTransform = _enemy.transform;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (_target.gameObject.tag != "Player") 
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(
                _enemyTransform.position, 
                _enemy.GetComponent<Enemy>().fovRange, 
                _playerLayerMask);

            if (colliders.Length > 0 ) 
            {
                return State.Success;
            }

            return State.Failure;
        }

        return State.Running;
    }
}
