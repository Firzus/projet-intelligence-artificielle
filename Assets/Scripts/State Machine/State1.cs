using UnityEngine;

public class State1 : BaseState // movement 
{
    public GameObject A, B;
    bool loop = false;
    private float speed = 2.0f;
    public override void EnterState(StateManager stateObject)
    {
        //Debug.Log("Entering State 1 ");
        A = GameObject.Find("/Waypoint/A");
        B = GameObject.Find("/Waypoint/B");
    }

    public override void UpdateState(StateManager stateObject)
    {
        if (loop == false)
        {
            PointA(stateObject);
        }
        else
        {
            PointB(stateObject);
        }
        //switch state 
        //stateObject.SwitchState(stateObject.state2);
    }

    private void PointA(StateManager stateObject)
    {
        Vector3 destination = B.transform.position;
        Vector3 newPos = Vector3.MoveTowards(stateObject.transform.position, destination, speed * Time.deltaTime);
        stateObject.transform.position = newPos;
        float distance = Vector3.Distance(stateObject.transform.position, destination);
        if (distance == 0.0f)
        {
            loop = true;
        }
    }

    private void PointB(StateManager stateObject)
    {
        Vector3 destination = A.transform.position;
        Vector3 newPos = Vector3.MoveTowards(stateObject.transform.position, destination, speed * Time.deltaTime);
        stateObject.transform.position = newPos;
        float distance = Vector3.Distance(stateObject.transform.position, destination);
        if (distance == 0.0f)
        {
            loop = false;
        }
    }
}
