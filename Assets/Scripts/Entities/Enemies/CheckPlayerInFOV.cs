using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckPlayerInFOV : Node
{
    private Transform _tranform;

    private Animator _animator;

    private static int _playerLayerMask = 1 << 6;

    public CheckPlayerInFOV(Transform tranform)
    {
        _tranform = tranform;
        _animator = tranform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object p = GetData("Player");

        if (p == null)
        {
            Collider2D[] collider = Physics2D.OverlapCircleAll(
                _tranform.position,
                BasicBulletBT.fovRange,
                _playerLayerMask);

            if (collider.Length > 0 ) 
            {
                parent.parent.SetData("Walking", true);
                //_animator.SetBool("Walking", true);
                state = NodeState.SUCCESS;
                return state;
            }

            
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
