using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ActionNode
{
    [HideInInspector] private Boss _boss;

    protected override void OnStart()
    {
        _boss = agent.GetComponent<Boss>();
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (agent._currentHp <= (agent._currentHp/agent._maxHp) * 100) 
        {
            if (!_boss.isShieldHandler)
            {
                _boss.StartCoroutine(_boss.ShieldHandler());
            }
            if (_boss.shieldOn) 
            {
                Instantiate(_boss._shield, agent.transform.position, Quaternion.identity);
                return State.Success;
            }
        }
        else if (agent._currentHp >= (agent._currentHp / agent._maxHp) * 100)
        {
            return State.Failure;
        }
        return State.Running;
    }
}
