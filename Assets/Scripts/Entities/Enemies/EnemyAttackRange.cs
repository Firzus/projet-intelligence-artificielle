using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public bool _isInRange;
    public bool _playerIn;
    public bool _playerOut;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isInRange = true;
        }
    }
}
