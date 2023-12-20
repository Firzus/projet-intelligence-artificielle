using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashOnPlayer : ActionNode
{
    [SerializeField] private Vector2 jumpPos;
    [HideInInspector] private GameObject _target;
    [HideInInspector] private GameObject _enemy;
    [HideInInspector] private Transform _enemyTransform;
    [HideInInspector] private Boss _boss;

    protected override void OnStart()
    {
        _target = GameObject.FindWithTag("Player");
        _enemy = agent.gameObject;
        _enemyTransform = _enemy.transform;
        _boss = agent.GetComponent<Boss>();
        jumpPos = _target.transform.position;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(_enemyTransform.position, _target.transform.position);

        if (dist >= agent.fovRange && _boss.canDash == true)
        {
            if (!_boss.isDashHandler)
            {
                _boss.StartCoroutine(_boss.DashHandler());
            }
            if (_boss.isDashing) 
            {
                _enemyTransform.position = Vector2.MoveTowards(_enemyTransform.position, jumpPos, Time.deltaTime * agent._speed * 10);
                return State.Success;
            }
        }
        else if (dist <= agent.fovRange || _boss.canDash == false)
        {
            return State.Failure;
        }
        return State.Running;
    }
}
