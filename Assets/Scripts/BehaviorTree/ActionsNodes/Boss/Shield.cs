using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ActionNode
{
    [HideInInspector] private Boss _boss;
    [HideInInspector] private bool isCreated;

    protected override void OnStart()
    {
        isCreated = false;
        _boss = agent.GetComponent<Boss>();
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (agent.CurrentHp <= (agent.CurrentHp/agent.MaxHp) * 100) 
        {
            if (!_boss.isShieldHandler)
            {
                _boss.StartCoroutine(_boss.ShieldHandler());
            }
            if (_boss.shieldOn) 
            {
                if (!isCreated)
                {
                    Instantiate(_boss._shield, agent.transform.position, Quaternion.identity, agent.transform);
                    isCreated = true;
                }
               
                return State.Success;
            }
        }
        else if (agent.CurrentHp > (agent.CurrentHp / agent.MaxHp) * 100)
        {
            return State.Failure;
        }
        return State.Running;
    }
}
