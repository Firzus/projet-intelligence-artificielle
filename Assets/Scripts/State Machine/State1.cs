using UnityEngine;

public class State1 : BaseState // movement 
{
    public override void EnterState(StateManager stateObject)
    {
        Debug.Log("Entering State 1 ");
    }

    public override void UpdateState(StateManager stateObject)
    {
        Debug.Log("Updating state 1");
        //switch state 
        //stateObject.SwitchState(stateObject.state2);
    }
}
