using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private const string IDLE_LEFT = "Man_Bandana_Idle_Left";
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
        
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
        if(col.CompareTag("Player")){
            enemy.SwitchState(enemy.chase);
        }
    }
}
