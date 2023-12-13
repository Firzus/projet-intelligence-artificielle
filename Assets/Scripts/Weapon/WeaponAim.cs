using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] bool _FlipRight = true;

    private SpriteRenderer _sp;
    private Vector3 _targetPosition;
    private Vector2 _worldposition;
    private Vector2 _direction;

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
        _worldposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = (_worldposition - (Vector2)transform.position).normalized;
        transform.right = _direction;
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
