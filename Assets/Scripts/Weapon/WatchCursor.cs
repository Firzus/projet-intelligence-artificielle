using UnityEngine;

public class WatchCursor : MonoBehaviour
{
    public GameObject _target;
    [SerializeField] float _speed;
    [SerializeField] float _rotationModifier;
    [SerializeField] bool _FlipRight = true;

    private SpriteRenderer _sp;

    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        if(_FlipRight == false)
        {
            _sp.flipY = true;
        }
    }

    private void FixedUpdate()
    {
        Flip();
        Vector3 vectorToTarget = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - _rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _speed);
    }

    private void Flip()
    {
        if (_FlipRight && transform.rotation.z >= 0.72f || _FlipRight && transform.rotation.z <= -0.72f)
        {
            _FlipRight = false;
            _sp.flipY = true;
        }
        
        else if (_FlipRight==false && transform.rotation.z <= 0.72f && transform.rotation.z >= -0.72f)
        {
            _FlipRight = true;
            _sp.flipY = false;
        }

    }
}
