using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
       Debug.Log("Attack Mode");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        throw new System.NotImplementedException();
    }
}
