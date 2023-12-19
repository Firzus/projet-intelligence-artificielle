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
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        //Debug.Log("Trigger " + col.tag);
        //switch state if trigger
        if (col.CompareTag("Player") && enemy.name == "Simple Bullet")
        {
            enemy.SwitchState(enemy.attack);
        }
        else if (col.CompareTag("Player") && enemy.name == "Elite Bullet")
        {
            enemy.SwitchState(enemy.moving);
        }
    }

    private void Chase(EnemyStateManager enemy)
    {
        float speed = 2.0f;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.player.transform.position, speed * Time.deltaTime);
    }

    private void RayCast(EnemyStateManager enemy)
    {
        Vector3 origin = enemy.GetComponent<CircleCollider2D>().bounds.center + new Vector3(enemy.GetComponent<CircleCollider2D>().bounds.extents.x + 0.5f, 0f, 0f);
        Vector2 destination = enemy.player.transform.position - origin;

        RaycastHit2D hit = Physics2D.Raycast(origin, destination);
        Debug.DrawRay(origin, destination , Color.red);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
    }
}
