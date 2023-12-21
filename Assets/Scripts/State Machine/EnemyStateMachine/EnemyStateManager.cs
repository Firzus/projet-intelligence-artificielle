using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    //calling state class
    EnemyBaseState currentState;
    public EnemyLoadingState loading = new EnemyLoadingState();
    public EnemyChaseState chase = new EnemyChaseState();
    public EnemyAttackState attack = new EnemyAttackState();
    public EnemyDeathState death = new EnemyDeathState();

    //other class
    public GameObject player;
    public NavMeshAgent agent;
    public EntityState entity;
    // Variable
    public Animator animator;
    public bool CheckDeath = false;
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
