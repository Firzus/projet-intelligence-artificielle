using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Attack Mode");
        
        enemy.agent.ResetPath();
        enemy.agent.velocity = Vector2.zero;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.CheckDeath)
            enemy.SwitchState(enemy.death);
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.shoot.RangeShoot = true;
        }

    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
        if (col.CompareTag("Player")){
            enemy.shoot.RangeShoot = false;
            enemy.SwitchState(enemy.chase);
        }
    }
}
