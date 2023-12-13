using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class GoToTarget : Node
{
    private Transform _transform;

    public GoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("Player");

        Debug.Log(target);

        if (Vector2.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector2.MoveTowards(
                _transform.position,
                target.position,
                BasicBulletBT.speed * Time.deltaTime);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
