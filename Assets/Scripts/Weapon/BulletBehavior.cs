using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 15f;
    [SerializeField] float _lifeTime = 2f;
    [SerializeField] GameObject _RpgExplosion;

    private Transform _parentType;
    void Start()
    {
        _parentType = gameObject.transform.parent;
        SetStraingVelocity();
    }

    void Update()
    {
        _lifeTime -= Time.deltaTime;
        TestDestroy();
        
    }

    private void SetStraingVelocity()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void TestDestroy()
    {
        if(_lifeTime < 0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string entityShooter = _parentType.tag;
        if (entityShooter == "PlayerManager")
        {
            if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet"))
            {
                BulletExplosion();
            }
        }
        else
        {
            if (!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bullet"))
            {
                BulletExplosion();
            }
        }
    }


    private void BulletExplosion()
    {
        if (gameObject.CompareTag("ExplosifBullet"))
        {
            Instantiate(_RpgExplosion, gameObject.transform.position, Quaternion.identity, _parentType);
        }
        Destroy(gameObject);       
    }
}
