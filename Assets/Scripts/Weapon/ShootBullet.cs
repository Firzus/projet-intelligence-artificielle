using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _weapon;
    public Transform _bulletStartPoint;
    public GameObject _target;
    private GameObject _bulletInst;

    void Start()
    {
        
    }

    void Update()
    {
        //HandGunShooting(_bullet);
    }

    public void HandGunShooting(GameObject bullet)
    {

        _bulletInst = Instantiate( bullet, _bulletStartPoint.position, _weapon.transform.rotation);
     
    }
}
