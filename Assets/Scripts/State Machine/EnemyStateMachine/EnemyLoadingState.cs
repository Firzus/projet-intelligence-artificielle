using UnityEngine;
using UnityEngine.AI;

public class EnemyLoadingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        //enemy is dead
        if (BoolCreateWeapon(enemy))
            enemy.SwitchState(enemy.chase);

        enemy.player = GameObject.FindGameObjectWithTag("Player");

        enemy.entity = enemy.GetComponent<EntityState>();

        enemy.shoot = enemy.GetComponent<ShootStyle>();

        enemy.agent = enemy.GetComponent<NavMeshAgent>();
        enemy.agent.updateRotation = false;
        enemy.agent.updateUpAxis = false;
        enemy.agent.velocity = new Vector2(enemy.entity.Speed, enemy.entity.Speed);

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
            if (enemy.name != "Kamikaze")
            {
                weapon.Init();
                weapon.SetWeapon(enemy);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
