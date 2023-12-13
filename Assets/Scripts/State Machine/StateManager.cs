using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;
    public State1 state1 = new State1();
    public  State2 state2 = new State2();
    // Start is called before the first frame update
    void Start()
    {
        currentState = state1;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(BaseState state){
        currentState = state;
        state.EnterState(this);
    }
}
