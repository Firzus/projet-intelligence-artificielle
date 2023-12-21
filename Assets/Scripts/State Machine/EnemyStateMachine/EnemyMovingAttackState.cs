using UnityEngine;

public class EnemyMovingAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enter to Moving State");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.CheckDeath)
            enemy.SwitchState(enemy.death);
        //Chase(enemy);
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
    }

    private void Chase(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.player.transform.position);
    }
}
