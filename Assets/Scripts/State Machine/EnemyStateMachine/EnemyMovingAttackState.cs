using UnityEngine;

public class EnemyMovingAttackState : EnemyBaseState
{
    GameObject target;
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enter to Moving State");
        target = GameObject.Find("player");//player
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        Chase(enemy);
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        throw new System.NotImplementedException();
    }

    private void Chase(EnemyStateManager enemy)
    {
        float speed = 4.0f;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
