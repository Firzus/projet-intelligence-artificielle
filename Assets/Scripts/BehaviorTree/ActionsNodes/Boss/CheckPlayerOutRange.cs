using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerOutRange : ActionNode
{
    [HideInInspector] private GameObject _target;
    private float fovRange;
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

        if (dist >= fovRange)
        {
            Debug.Log($"Out of Range. {dist}");
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
