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
        _shootCooldown = 1f;
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
        //Debug.Log(_shootCooldown);

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
                    Rafale(3, 1f);
                    _shootCooldown = 1.2f;
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
        float temps = t;
        while (number >= 0)
        {
            temps -= Time.deltaTime;
            if (temps < 0)
            {
                Debug.Log(temps);
                _shootBullet.HandGunShooting(_simpleBullet);
                temps = t;
                number--;
            }
        }
    }
}
