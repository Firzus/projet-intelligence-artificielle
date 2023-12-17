using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _speed = 15f;
    [SerializeField] float _lifeTime = 2;
    [SerializeField] GameObject _RpgExplosion;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.gameObject.name);
        if (this.gameObject.name == "rocketBullet(Clone)")
        {
            Debug.Log("a");
            Instantiate(_RpgExplosion, this.gameObject.transform.position, Quaternion.identity, GameObject.Find("BulletManager").transform);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
