 using UnityEngine;

public class EntityState : Entities
{
    private bool _isAlive;
    [SerializeField] bool _canMove = true;
    //[SerializeField] bool _canShoot = true;

    public bool CanMove { get => _canMove; set => _canMove = value; }

    void Start()
    {
        _isAlive = true;
    }

    void Update()
    {
        if(_currentHp <= 0)
        {
            _isAlive = false;
        }

        if (_isAlive && CanMove)
        {
            //
        }
    }
}
