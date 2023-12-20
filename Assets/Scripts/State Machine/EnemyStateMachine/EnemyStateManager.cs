using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    public EnemyLoadingState loading = new EnemyLoadingState();
    public EnemyChaseState chase = new EnemyChaseState();
    public EnemyAttackState attack = new EnemyAttackState();
    public EnemyMovingAttackState moving = new EnemyMovingAttackState();


    public GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = loading;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        currentState.OnTriggerEnter2D(this, col);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        currentState.OnTriggerExit2D(this, col);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
