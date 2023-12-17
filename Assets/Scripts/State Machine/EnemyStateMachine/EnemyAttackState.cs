using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Attack Mode");
        CreateWeapon weapon = enemy.GetComponent<CreateWeapon>();
        if (weapon != null)
            weapon.SetWeapon(enemy);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
    }
}
