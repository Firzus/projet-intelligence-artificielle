using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageMode : ActionNode
{
    [SerializeField] private float _currentBossHp;

    protected override void OnStart()
    {
        _currentBossHp = agent._currentHp;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (_currentBossHp < (_currentBossHp/agent._maxHp) * 100) 
        {
            agent._speed = agent._speed * 1.2f;
            return State.Success;
        }
        return State.Running;
    }
}
