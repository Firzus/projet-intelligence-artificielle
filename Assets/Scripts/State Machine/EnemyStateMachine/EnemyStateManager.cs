using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    public EnemyLoadingState loading = new EnemyLoadingState();
    public EnemyChaseState chase = new EnemyChaseState();
    public EnemyAttackState attack = new EnemyAttackState();
    public EnemyMovingAttackState moving = new EnemyMovingAttackState();
    public EnemyDeathState death = new EnemyDeathState();

    public GameObject player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    private void Start()
    {
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
