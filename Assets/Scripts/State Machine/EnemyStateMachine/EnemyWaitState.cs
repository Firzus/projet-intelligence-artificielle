using UnityEngine;

public class EnemyWaitState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.transform.GetChild(1).gameObject.SetActive(false);
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        CheckDoor(enemy, enemy.door.IsOpen);
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {

    }

    private void CheckDoor(EnemyStateManager enemy, bool check){
        if(check){
            enemy.transform.GetChild(1).gameObject.SetActive(true);
            enemy.SwitchState(enemy.chase);
        }
    }
}
