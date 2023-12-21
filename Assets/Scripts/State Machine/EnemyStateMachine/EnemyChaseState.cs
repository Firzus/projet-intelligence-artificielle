using NavMeshPlus.Extensions;
using UnityEngine;


public class EnemyChaseState : EnemyBaseState
{
    public bool? CheckrayCast = null;
    public override void EnterState(EnemyStateManager enemy)
    {

    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        if(enemy.CheckDeath)
            enemy.SwitchState(enemy.death);
        Chase(enemy);
        RayCast(enemy);
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        if (col.CompareTag("Player") && enemy.name == "Simple Bullet")
        {
            enemy.SwitchState(enemy.attack);
        }
        else if (col.CompareTag("Player") && enemy.name == "Elite Bullet")
        {
            enemy.SwitchState(enemy.moving);
        }
    }

    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
    }

    private void Chase(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.player.transform.position);
    }

    private void RayCast(EnemyStateManager enemy)
    {
        Vector3 orbitCenter = enemy.transform.GetChild(0).GetComponent<CircleCollider2D>().bounds.center;
        Vector3 destination = enemy.player.transform.position;

        Vector3 normal = (destination - orbitCenter).normalized;

        Vector3 origin = orbitCenter + normal * (enemy.transform.GetChild(0).GetComponent<CircleCollider2D>().radius + 0.1f);

        RaycastHit2D hit = Physics2D.Raycast(origin, destination - origin);
        Debug.DrawRay(origin, destination - origin, Color.red);

        if (hit.collider.tag == "Player")
        {
            CheckrayCast = true;
        }
        else
        {
            CheckrayCast = false;
        }
    }
}
