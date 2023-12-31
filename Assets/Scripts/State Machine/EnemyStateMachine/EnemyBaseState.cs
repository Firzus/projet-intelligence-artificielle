using UnityEngine;

public abstract class EnemyBaseState
{
   public abstract void EnterState(EnemyStateManager enemy);
   public abstract void UpdateState(EnemyStateManager enemy);
   public abstract void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col);
   public abstract void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col);
}
