using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootStyle : MonoBehaviour
{
    [SerializeField] GameObject _simpleBullet;
    [SerializeField] GameObject _mediumBullet;
    [SerializeField] GameObject _rocketBullet;
    [SerializeField] float _waitingMultiplicator = 1;

    private WeaponInventory _gunInv;
    private ShootBullet _shootBullet;
    private bool _canShootCooldown;
    private float _shootCooldown;
    private Transform _parent;
    private bool _waiting = false;
    private AudioSource _audioSource;
    void Start()
    {
        _parent = this.gameObject.transform.parent;
        _gunInv = _parent.GetComponent<WeaponInventory>();
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

        else if (_parent.tag == "Boss")
        {
            //Paterne du boss
        }

    }

    IEnumerator CooldownTime()
    {
        _waiting = true;
        yield return new WaitForSeconds(_shootCooldown * _waitingMultiplicator);
        _waiting = false;
        _canShootCooldown = true;
    }



    private void Shoot()
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
                    StartCoroutine(Rafale(3, 0.1f));
                    break;

                case "rocket":
                    _shootBullet.HandGunShooting(_rocketBullet);
                    _audioSource.Play();
                    _shootCooldown = 3f;
                    break;

                case "shotgun":
                    StartCoroutine(Shotgun());
                    _shootCooldown = 2f;
                    break;

                case "minigun":
                    StartCoroutine(Minigun());
                    _shootCooldown = 10f;
                    break;
                default:
                    break;

            }
            _canShootCooldown = false;
        }
    }
    IEnumerator Rafale(int number, float t)
    {
        for (int i = 0; i < number; i++)
        {
            _shootBullet.HandGunShooting(_simpleBullet);
            _audioSource.Play();
            yield return new WaitForSeconds(t);
        }

        yield return new WaitForSeconds(_shootCooldown);
    }
    IEnumerator Shotgun()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(1f);
        _shootBullet.HandGunShooting(_mediumBullet, 0.1f);
        _shootBullet.HandGunShooting(_mediumBullet, 0f);
        _shootBullet.HandGunShooting(_mediumBullet, -0.1f);
    }

    IEnumerator Minigun()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(1f);
        for (int i = 0;i < 65;i++)
        {
            yield return new WaitForSeconds(0.05f);
            _shootBullet.HandGunShooting(_simpleBullet);
        }
        
    }
}
