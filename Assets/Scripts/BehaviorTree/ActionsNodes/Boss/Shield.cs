using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ActionNode
{
    [HideInInspector] private Boss _boss;
    private GameObject shieldClone;

    protected override void OnStart()
    {
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
                if (shieldClone == null)
                {
                    shieldClone = Instantiate(_boss._shield, agent.transform.position, Quaternion.identity, agent.transform);
                }

                Destroy(shieldClone, 3f);

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
