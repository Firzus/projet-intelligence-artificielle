using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
   
    GameObject target;
    public override void EnterState(EnemyStateManager enemy)
    {
        target = GameObject.Find("enemy");
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
        float speed = 2.0f;
        Vector3 MovingOntarget = Vector3.MoveTowards(enemy.transform.position, target.transform.position, speed * Time.deltaTime);
        enemy.transform.position = MovingOntarget;
    }
}
