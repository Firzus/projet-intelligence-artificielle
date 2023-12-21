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
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string entityShooter = _parentType.tag;
        if (!collision.gameObject.CompareTag("RangeDetection"))
        {
            if (entityShooter == "EnemyManager")
            {
                if (!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("RangeDetection"))
                {
                    if (collision.CompareTag("Player"))
                    {
                        collision.GetComponent<EntityState>().Gethit();
                    }
                    BulletExplosion();
                }
            }
            else
            {
                if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Shield"))
                {
                    if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
                    {
                        collision.GetComponent<EntityState>().Gethit();
                    }
                    BulletExplosion();
                }
            }
        }

    }


    private void BulletExplosion()
    {
        if (gameObject.CompareTag("ExplosifBullet"))
        {
            GameObject explosion = Instantiate(_RpgExplosion, gameObject.transform.position, Quaternion.identity, _parentType);
            explosion.transform.localScale = new Vector3(5, 5, 0);
        }
        Destroy(gameObject);
    }
}
