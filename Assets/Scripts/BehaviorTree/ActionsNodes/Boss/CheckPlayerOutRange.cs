using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerOutRange : ActionNode
{
    [HideInInspector] private GameObject _target;
    private float _fovRange;
    [SerializeField] private float dist;

    public bool outRange;
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
        dist = Vector2.Distance(agent.transform.position, _target.transform.position);

        if (dist >= _fovRange)
        {
            //Debug.Log($"Out of Range. {dist}");
            outRange = true;
            return State.Success;
        }
        else if (dist <= _fovRange)
        {
            outRange = false;
            return State.Failure;
        }

        return State.Running;
    }
}
