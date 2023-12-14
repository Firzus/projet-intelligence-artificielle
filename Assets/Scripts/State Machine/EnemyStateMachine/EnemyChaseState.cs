using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
   
    GameObject target;
    public override void EnterState(EnemyStateManager enemy)
    {
        target = GameObject.Find("player");//player
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Chase(enemy);
    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        //switch state if trigger
        Debug.Log("Trigger " + col.name);
        if (col.name == "player" && enemy.name == "Simple Bullet")
        {
            enemy.SwitchState(enemy.attack);
        }
        else if(col.name == "player" && enemy.name == "Elite Bullet"){
            enemy.SwitchState(enemy.moving);
        }
    }

    private void Chase(EnemyStateManager enemy)
    {
        float speed = 2.0f;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
