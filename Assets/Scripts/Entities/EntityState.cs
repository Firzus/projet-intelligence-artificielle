using UnityEngine;

public class EntityState : Entities
{

    [SerializeField] bool _canMove = true;
    [SerializeField] EntityState _playerState;
    private int _killCount;

    public int KillCount { get => _killCount; set => _killCount = value; }
    public bool CanMove { get => _canMove; set => _canMove = value; }

    void Start()
    {
        _killCount = 0;
        if(_playerState != null)
        {
            GameObject p = GameObject.Find("Player");
            _playerState = p.GetComponent<EntityState>();
        }
        if(MaxHp == 0)
        {
            MaxHp = 1;
        }
        CurrentHp = MaxHp;
    }

    void Update()
    {
        if (CurrentHp <= 0)
        {
            _canMove = false;
            Dead();
        }
    }

    public virtual void EnemyStart(int maxHp, float speed)
    {
        MaxHp = maxHp;
        Speed = speed;
    }

    private void Dead()
    {
        Debug.Log("dead");
        if(gameObject.CompareTag("Enemy") || gameObject.CompareTag("Boss"))
        {
            _playerState.KillCount++;
            Debug.Log(_playerState.KillCount);
            Destroy(gameObject);

        }
        if(gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    public void Gethit()
    {
        CurrentHp--;
    }
}
