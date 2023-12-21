using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageMode : ActionNode
{
    [SerializeField] private float _currentBossHp;

    protected override void OnStart()
    {
        _currentBossHp = agent.CurrentHp;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (_currentBossHp < (_currentBossHp/agent.MaxHp) * 100) 
        {
            agent.Speed = 2f;
            return State.Success;
        }
        else if (_currentBossHp > (_currentBossHp/agent.MaxHp) * 100) 
        {
            return State.Failure;
        }
        return State.Running;
    }
}
