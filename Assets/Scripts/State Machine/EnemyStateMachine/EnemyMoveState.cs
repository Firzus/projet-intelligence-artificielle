using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
   public GameObject A, B;
    bool loop = false;
    public override void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("Entering State 1 ");
        A = GameObject.Find("/Waypoint/A");
        B = GameObject.Find("/Waypoint/B");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (loop == false)
        {
            PointA(enemy);
        }
        else 
        { 
            PointB(enemy);
        }
        //switch state 
        //enemy.SwitchState(enemy.state2);
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        //switch state if trigger
        Debug.Log("Trigger");
        if(col.name == "enemy"){
            enemy.SwitchState(enemy.chase);
        }
    }

    //Local function
    private void PointA(EnemyStateManager enemy)
    {
        float speed = 2.0f;
        Vector3 destination = B.transform.position;
        Vector3 newPos = Vector3.MoveTowards(enemy.transform.position, destination, speed * Time.deltaTime);
        enemy.transform.position = newPos;
        float distance = Vector3.Distance(enemy.transform.position, destination);
        if (distance == 0.0f)
        {
            loop = true;
        }
    }

    private void PointB(EnemyStateManager enemy)
    {
        float speed = 2.0f;
        Vector3 destination = A.transform.position;
        Vector3 newPos = Vector3.MoveTowards(enemy.transform.position, destination, speed * Time.deltaTime);
        enemy.transform.position = newPos;
        float distance = Vector3.Distance(enemy.transform.position, destination);
        if (distance == 0.0f)
        {
            loop = false;
        }
    }
}
