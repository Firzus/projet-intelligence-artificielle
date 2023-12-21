using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Death mode");
        //launch death animation
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
    }
}
