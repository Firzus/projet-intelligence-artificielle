using UnityEngine;


public class EnemyChaseState : EnemyBaseState
{
    public bool? CheckrayCast = null;
    private const string RUN_LEFT = "Man_Bandana_Run_Left";
    private const string RUN_RIGHT = "Man_Bandana_Run_Right";
    private const string IDLE_LEFT = "Man_Bandana_Idle_Left";
    private const string IDLE_RIGHT = "Man_Bandana_Idle_Right";
    public override void EnterState(EnemyStateManager enemy)
    {

    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        // if(enemy.CheckDeath)
        //     enemy.SwitchState(enemy.death);
        Chase(enemy);
        RayCast(enemy);
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.animator.Play(IDLE_LEFT);
            enemy.SwitchState(enemy.attack);
        }
        // else if (col.CompareTag("Player") && enemy.name == "Elite Bullet")
        // {
        //     enemy.SwitchState(enemy.moving);
        // }
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
    }

    private void Chase(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.player.transform.position);
        TestDirection(enemy);
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

    private void TestDirection(EnemyStateManager enemy)
    {
        float x = enemy.player.transform.position.x;
        if(x > enemy.transform.position.x)
        {
            enemy.animator.Play(RUN_RIGHT);
        }
        else
        {
            enemy.animator.Play(RUN_LEFT);
        }
    }
}
