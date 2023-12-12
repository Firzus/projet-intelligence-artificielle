using UnityEngine;

public class WatchCursor : MonoBehaviour
{
    public GameObject _target;
    public float _speed;
    public float _rotationModifier;

    public bool _FlipRight = true;
    private SpriteRenderer _sp;

    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        if(_FlipRight == false)
        {
            _sp.flipX = true;
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

        if (_FlipRight && transform.rotation.z >= 90)// || _FlipRight && transform.rotation.z <= -90)
        {
            Debug.Log("true");
            _FlipRight = false;
            _sp.flipX = true;
        }
        else
        {
            _FlipRight = true;
            _sp.flipX = false;
        }

    }
}
