using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    CreateWeapon weapon = new CreateWeapon();
    public override void EnterState(EnemyStateManager enemy)
    {
       Debug.Log("Attack Mode");
       
       //weapon.SetWeapon(enemy);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        throw new System.NotImplementedException();
    }
}
