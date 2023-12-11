using UnityEngine;

public class Enemy : Entities
{
    public bool _isInRange;
    public bool _playerIn;
    public bool _playerOut;

    public override void Destroy()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
