using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootStyle : MonoBehaviour
{
    [SerializeField] GameObject _simpleBullet;
    [SerializeField] GameObject _mediumBullet;
    [SerializeField] GameObject _rocketBullet;
    [SerializeField] WeaponInventory _gunInv;

    private ShootBullet _shootBullet;
    private bool _canShootCooldown;
    private float _shootCooldown;
    void Start()
    {
        _shootBullet = GetComponent<ShootBullet>();
        _canShootCooldown = false;
        _shootCooldown = 0f;
    }


    void Update()
    {
        CooldownTime();
        Shoot();
    }


    private void CooldownTime()
    {
        if (_shootCooldown <= 0)
        {
            _canShootCooldown = true;
        }
        _shootCooldown -= Time.deltaTime;
    }


    private void Shoot()
    {
        if (_canShootCooldown==true && Input.GetMouseButtonDown(0))
        {
            switch (_gunInv.ActualWeapon.Type)
            {
                case "pistolet":
                    _shootBullet.HandGunShooting(_mediumBullet);
                    _shootCooldown = 0.6f;
                    break;

                case "rafale":
                    _shootCooldown = 1.2f;
                    Rafale(3, 0.1f);
                    break;

                case "lourd":
                    _shootBullet.HandGunShooting(_rocketBullet);
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
            yield return new WaitForSeconds(t);
        }

        yield return new WaitForSeconds(_shootCooldown);
    }
}
