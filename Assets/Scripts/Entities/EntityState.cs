using UnityEngine;

public class EntityState : Entities
{
    [SerializeField] bool _canMove = true;
    [SerializeField] EntityState _playerState;
    //EnemyStateManager enemy;
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

        Debug.Log("max xp : " + MaxXp);
    }

    public virtual void EnemyStart(int maxHp, float speed)
    {
        MaxHp = maxHp;
        Speed = speed;
    }

    private void Dead()
    {
        // Obtenez la r�f�rence � l'�tat du joueur si n�cessaire
        _playerState = GameObject.FindWithTag("Player").GetComponent<EntityState>();

        // V�rifiez si l'objet est un ennemi ou un boss
        if (gameObject.CompareTag("Enemy"))
        {
            AddXP(200);

            if (_playerState != null)
            {
                _playerState.KillCount++;
            }
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Boss"))
        {
            //AddXP(500);

            if (_playerState != null)
            {
                _playerState.KillCount++;
            }
            Destroy(gameObject);
        }
        // Sinon, v�rifiez si l'objet est le joueur
        else if (gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void Gethit()
    {
        CurrentHp--;
    }

    public void AddXP(int amount)
    {
        CurrentXp += amount;
        if (CurrentXp > MaxXp)
        {
            CurrentXp = MaxXp;
        }

        Debug.Log($"Current XP: {CurrentXp} / Max XP: {MaxXp}");
    }
}