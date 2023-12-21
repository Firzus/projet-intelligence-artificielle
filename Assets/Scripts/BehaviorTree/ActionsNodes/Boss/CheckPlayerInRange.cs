using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInRange : ActionNode
{
    [HideInInspector] private GameObject _target;
    private float _fovRange;
    public bool inRange;

    protected override void OnStart()
    {
        _target = GameObject.FindWithTag("Player");
        _fovRange = agent.FovRange;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(agent.transform.position, _target.transform.position);

        if (dist <= _fovRange)
        {
            //Debug.Log($"Within Range. {dist}");
            inRange = true;
            return State.Success;
        }
        else if (dist >= _fovRange)
        {
            inRange = false;
            return State.Failure;
        }

        return State.Running;
    }
}
