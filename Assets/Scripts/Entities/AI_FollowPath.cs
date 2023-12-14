using System.Collections;
using UnityEngine;

public class AI_FollowPath : MonoBehaviour
{
    public AI_PathPoint _point;
    [SerializeField] bool _followPath = true;
    private float _speed = 5f;
    private bool _wainting;
    void Start()
    {
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
                MoveToPoint();
            }
        }
    }

    private void MoveToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _point.Next.position, _speed * Time.deltaTime);
    }

    IEnumerator NextPointCooldown()
    {
        yield return new WaitForSeconds(2f);
        _point.ChangePoint();
        MoveToPoint();
        _wainting = false;
    }
}
