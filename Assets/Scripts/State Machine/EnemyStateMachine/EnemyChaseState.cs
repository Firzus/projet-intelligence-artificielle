using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{

    GameObject target;
    public override void EnterState(EnemyStateManager enemy)
    {
        target = GameObject.FindGameObjectWithTag("Player");//player
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Chase(enemy);
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
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
