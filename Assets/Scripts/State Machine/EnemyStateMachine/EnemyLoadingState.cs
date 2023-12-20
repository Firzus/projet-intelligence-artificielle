using UnityEngine;

public class EnemyLoadingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enter Loading mode");
        if (BoolCreateWeapon(enemy))
            enemy.SwitchState(enemy.chase);
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

    private bool BoolCreateWeapon(EnemyStateManager enemy)
    {
        CreateWeapon weapon = enemy.GetComponent<CreateWeapon>();
        if (weapon != null)
        {
            weapon.Init();
            weapon.SetWeapon(enemy);
            return true;
        }
        else
        {
            return false;
        }
    }
}
