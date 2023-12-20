using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInRange : ActionNode
{
    [HideInInspector] private GameObject _target;
    private float fovRange;
    public bool inRange;

    protected override void OnStart()
    {
        _target = GameObject.FindWithTag("Player");
        fovRange = agent.fovRange;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(agent.transform.position, _target.transform.position);

        if (dist <= fovRange)
        {
            //Debug.Log($"Within Range. {dist}");
            inRange = true;
            return State.Success;
        }
        else if (dist >= fovRange)
        {
            inRange = false;
            return State.Failure;
        }

        return State.Running;
    }
}
