using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootStyle : MonoBehaviour
{
    [SerializeField] GameObject _simpleBullet;
    [SerializeField] GameObject _mediumBullet;
    [SerializeField] GameObject _rocketBullet;
    [SerializeField] WeaponInventory _gunInv;
    [SerializeField] float _waitingMultiplicator = 1;

    public bool _waiting = false;

    private ShootBullet _shootBullet;
    private bool _canShootCooldown;
    private float _shootCooldown;
    private Transform _parent;
    private AudioSource _audioSource;
    void Start()
    {
        _parent = this.gameObject.transform.parent;
        _shootBullet = GetComponent<ShootBullet>();
        _canShootCooldown = false;
        _shootCooldown = 0f;
        _audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

        if(_parent.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            if(_waiting == false)
            {
                Shoot();
                StartCoroutine(CooldownTime());
            }
        }

        else if(_parent.tag == "Enemy")
        {
            if (_waiting == false)
            {
                Shoot();
                StartCoroutine(CooldownTime());
            }
        }

    }

    public IEnumerator CooldownTime()
    {
        _waiting = true;
        yield return new WaitForSeconds(_shootCooldown * _waitingMultiplicator);
        _waiting = false;
        _canShootCooldown = true;
    }



    public void Shoot()
    {
        if (_canShootCooldown==true)
        {
            _audioSource.clip = _gunInv.ActualWeapon.audio;
            switch (_gunInv.ActualWeapon.Type)
            {        
                case "pistolet":
                    _shootBullet.HandGunShooting(_mediumBullet);
                    _audioSource.Play();
                    _shootCooldown = 0.6f;
                    break;

                case "rafale":
                    _shootCooldown = 1.2f;
                    Rafale(3, 0.1f);
                    break;

                case "rocket":
                    _shootBullet.HandGunShooting(_rocketBullet);
                    _audioSource.Play();
                    _shootCooldown = 3f;
                    break;

                default:
                    break;

            }
            _canShootCooldown = false;
        }
    }


    private void Rafale(int number, float t)
    {
        Coroutine c = StartCoroutine(CoolDown(number, t));
    }


    IEnumerator CoolDown(int number, float t)
    {
        for (int i = 0; i < number; i++)
        {
            _shootBullet.HandGunShooting(_simpleBullet);
            _audioSource.Play();
            yield return new WaitForSeconds(t);
        }

        yield return new WaitForSeconds(_shootCooldown);
    }
}
