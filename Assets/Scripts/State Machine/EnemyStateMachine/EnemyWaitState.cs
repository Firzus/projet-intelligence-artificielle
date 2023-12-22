using UnityEngine;

public class EnemyWaitState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        CheckDoor(enemy, true);
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {

    }

    private void CheckDoor(EnemyStateManager enemy, bool check){
        if(check){
            enemy.SwitchState(enemy.chase);
        }
    }
}
