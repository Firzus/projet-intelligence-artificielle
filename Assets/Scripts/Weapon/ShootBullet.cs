using Unity.VisualScripting;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    private GameObject _weapon;
    private Transform _bulletStartPoint;
    private GameObject _bulletInst;

    void Start(){
        _weapon = this.gameObject;
        _bulletStartPoint = this.gameObject.transform.GetChild(0);
    }

    public void HandGunShooting(GameObject bullet, float a = 0f)
    {
        Quaternion rotation = _weapon.transform.rotation;
        rotation.z += a;
        _bulletInst = Instantiate(bullet, _bulletStartPoint.position, rotation, this.gameObject.transform.parent.parent);     
    }
}
