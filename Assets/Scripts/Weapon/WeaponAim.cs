using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public GameObject _target;
    private bool _FlipRight = true;
    private SpriteRenderer _sp;
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        if (_FlipRight == false)
        {
            _sp.flipY = true;
        }
    }

    void Update()
    {
        HandleGunRotation();
        Flip();
    }

    private void HandleGunRotation()
    {
        var dir = _target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Flip()
    {
        if (_FlipRight && transform.rotation.z >= 0.72f || _FlipRight && transform.rotation.z <= -0.72f)
        {
            _FlipRight = false;
            _sp.flipY = true;
        }

        else if (_FlipRight == false && transform.rotation.z <= 0.72f && transform.rotation.z >= -0.72f)
        {
            _FlipRight = true;
            _sp.flipY = false;
        }
    }
}
