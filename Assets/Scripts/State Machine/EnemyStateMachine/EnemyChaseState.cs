using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{

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
        Vector3 origin = enemy.transform.position;
        Vector3 destination = enemy.player.transform.position - enemy.transform.position;
        float rayLenght = 1;
        Debug.DrawRay(enemy.transform.position, destination, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(origin, destination, rayLenght);

        if(hit.collider){
            Debug.Log(hit.collider.name);
            destination = hit.point;
        }
    }
}
