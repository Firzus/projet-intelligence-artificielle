using System.Collections;
using UnityEngine;

public class AI_FollowPath : MonoBehaviour
{
    public AI_PathPoint _point;
    [SerializeField] bool _followPath = true;
    [SerializeField] Animator _animator;
    [SerializeField] EntityState _entityState;
    private bool _wainting;
    private bool _isMoving;

    private const string RUN_LEFT = "Enemy_Run_Left";
    private const string RUN_RIGHT = "Enemy_Run_Right";
    private const string IDLE_LEFT = "Enemy_Idle_Left";
    private const string IDLE_RIGHT = "Enemy_Idle_Right";
    void Start()
    {
        _animator.Play(IDLE_LEFT);
        _isMoving = false;
        if (_point == null)
        {
            _followPath = false;
        }
        else
        {
            _point.Index = 0;
            _wainting = false;
            _point.Next = _point._listPoint[_point.Index].transform;
        }

    }


    void Update()
    {
        //tire de temps en temps

        if (_followPath)
        {
            //suis le chemin
            if(this.gameObject.transform.position == _point.Next.position && _wainting == false)
            {
                _wainting = true;
                Coroutine c = StartCoroutine(NextPointCooldown());
            }
            else
            {
                if(_isMoving == false)
                {
                    MovingDirection();
                    _isMoving = true;
                }
                MoveToPoint();
            }
        }
    }

    private void MovingDirection()
    {
        if(gameObject.transform.position.y > _point.Next.position.y)
        {
            _animator.Play(RUN_RIGHT);
        }
        else
        {
            _animator.Play(RUN_LEFT);
        }
    }
    private void MoveToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _point.Next.position, _entityState.Speed * Time.deltaTime);
    }

    IEnumerator NextPointCooldown()
    {
        _animator.Play(IDLE_LEFT);
        yield return new WaitForSeconds(2f);
        _point.ChangePoint();
        MoveToPoint();
        _wainting = false;
        _isMoving = false;
    }
}
