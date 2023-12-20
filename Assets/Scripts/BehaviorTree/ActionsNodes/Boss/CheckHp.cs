using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHp : ActionNode
{
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (agent._currentHp < (agent._currentHp/agent._maxHp) * 100)
        {
            //Rage mode
            return State.Success;
        }
        return State.Failure;
    }
}
