using UnityEngine;

public class State1 : BaseState // movement 
{
    public override void EnterState(StateManager stateObject)
    {
       //Enter code here
    }

    public override void UpdateState(StateManager stateObject)
    {
        //Update code here

        //switch state 
        //stateObject.SwitchState(stateObject.state2);
    }
}