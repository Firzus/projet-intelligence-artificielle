 using UnityEngine;

public class PlayerState : Entities
{
    private bool _isAlive;
    public bool _canMove = true;
    public bool _canShoot = true;

    void Start()
    {
        _isAlive = true;
    }

    void Update()
    {
        if(_hp <= 0)
        {
            _isAlive = false;
        }

        if (_isAlive && _canMove)
        {

        }
    }

    public override void Destroy()
    {

    }
}
