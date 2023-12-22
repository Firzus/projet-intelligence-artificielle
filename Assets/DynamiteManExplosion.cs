using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteManExplosion : MonoBehaviour
{
    [SerializeField] CircleCollider2D _collider;
    [SerializeField] EntityState _state;
    [SerializeField] Animator _animator;

    private const string RUN_LEFT = "Dynamite_Man_Run_Left";
    private const string RUN_RIGHT = "Dynamite_Man_Run_Right";
    private const string IDLE = "Dynamite_Man_Idle";
    private const string EXPLOSE = "Dynamite_Man_Explose";
    void Start()
    {
        _animator.Play(IDLE);
        if (_collider == null)
        {
            _collider = gameObject.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>();
        }
        if(_state == null)
        {
            _state = gameObject.GetComponent<EntityState>();
        }
    }

    void Update()
    {
        if (_state.CurrentHp <= 0)
        {
            StartCoroutine(Explode());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    IEnumerator Explode()
    {
        _animator.Play(EXPLOSE);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
