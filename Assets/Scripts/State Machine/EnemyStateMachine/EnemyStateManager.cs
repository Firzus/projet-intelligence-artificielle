using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    public EnemyMoveState move = new EnemyMoveState();
    public  EnemyChaseState chase = new EnemyChaseState();
    // Start is called before the first frame update
    void Start()
    {
        currentState = move;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        currentState.OnTriggerEnter2D(this, col);
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        state.EnterState(this);
    }
}
