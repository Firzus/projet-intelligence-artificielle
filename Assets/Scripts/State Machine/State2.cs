using UnityEngine;

public class State2 : BaseState // chase player
{
    public override void EnterState(StateManager stateObject)
    {
        Debug.Log("Entering state 2");
    }

    public override void UpdateState(StateManager stateObject)
    {
        Debug.Log("Updating state 2");


    }
}
