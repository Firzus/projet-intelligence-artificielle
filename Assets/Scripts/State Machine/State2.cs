using UnityEngine;

public class State2 : BaseState // chase player
{
    GameObject target;
    public override void EnterState(StateManager stateObject)
    {
        target = GameObject.Find("enemy");
    }
    public override void UpdateState(StateManager stateObject)
    {
        Chase(stateObject);
    }
    public override void OnTriggerEnter(StateManager stateObject, Collider other)
    {
        throw new System.NotImplementedException();
    }

    private void Chase(StateManager stateObject)
    {
        float speed = 2.0f;
        Vector3 MovingOntarget = Vector3.MoveTowards(stateObject.transform.position, target.transform.position, speed * Time.deltaTime);
        stateObject.transform.position = MovingOntarget;
    }
}
