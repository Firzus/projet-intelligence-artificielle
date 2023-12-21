using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EntityState : Entities
{
    [SerializeField] bool _canMove = true;
    [SerializeField] EntityState _playerState;
    [SerializeField] ParticleSystem _hitParticle;
    private int _killCount;
    
    public int KillCount { get => _killCount; set => _killCount = value; }
    public bool CanMove { get => _canMove; set => _canMove = value; }

    void Start()
    {
        _killCount = 0;

        if (_playerState != null)
        {
            _playerState = GameObject.FindWithTag("Player").GetComponent<EntityState>();
        }
        if (MaxHp == 0)
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

    public void Dead()
    {
        _playerState = GameObject.FindWithTag("Player").GetComponent<EntityState>();

        if (gameObject.CompareTag("Enemy"))
        {
            if (_playerState != null)
            {
                _playerState.KillCount++;
            }
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Boss"))
        {
            if (_playerState != null)
            {
                _playerState.KillCount++;
            }
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Gethit()
    {
        CurrentHp--;
        Instantiate(_hitParticle, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        _hitParticle.Play();
    }
}