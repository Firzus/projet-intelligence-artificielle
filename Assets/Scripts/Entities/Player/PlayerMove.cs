using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerState State;

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
        if(State._canMove == true)
        {
            OnMove(State._speed);
        }
    }

    public void OnMove(float speed)
    {
        _rb.velocity = new Vector2(_horizontal * speed, _vertical * speed);
    }
}
