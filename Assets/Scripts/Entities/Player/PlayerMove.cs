using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool _canMove = true;
    public float _speed = 10.0f;

    private float _horizontal;
    private float _vertical;

    [SerializeField] private Rigidbody2D _rb;


    void Start()
    {

    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(_canMove == true)
        {
            OnMove(_speed);
        }
    }

    public void OnMove(float speed)
    {
        _rb.velocity = new Vector2(_horizontal * speed, _vertical * speed);
    }
}
