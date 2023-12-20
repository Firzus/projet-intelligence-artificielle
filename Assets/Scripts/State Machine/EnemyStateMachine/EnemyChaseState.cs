using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    //LayerMask IgnoreLayer = LayerMask.GetMask("Default");
    public override void EnterState(EnemyStateManager enemy)
    {
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Chase(enemy);
        RayCast(enemy);
        //Debug.Log(RayCast(enemy));
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        //Debug.Log("Trigger " + col.tag);
        //switch state if trigger
        if (col.CompareTag("Player") && enemy.name == "Simple Bullet")
        {
            enemy.SwitchState(enemy.attack);
        }
        else if (col.CompareTag("Player") && enemy.name == "Kamikaze")
        {
            enemy.SwitchState(enemy.death);
        }
    }

    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {
    }

    private void Chase(EnemyStateManager enemy)
    {
        float speed = 2.0f;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.player.transform.position, speed * Time.deltaTime);
    }

    private bool RayCast(EnemyStateManager enemy)
    {
        Vector3 orbitCenter = enemy.GetComponent<CircleCollider2D>().bounds.center;
        Vector3 destination = enemy.player.transform.position;

        Vector3 normal = (destination - orbitCenter).normalized;

        Vector3 origin = orbitCenter + normal * (enemy.GetComponent<CircleCollider2D>().radius + 0.1f);

        RaycastHit2D hit = Physics2D.Raycast(origin, destination - origin);
        Debug.DrawRay(origin, destination - origin, Color.red);

        if (hit.collider.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
