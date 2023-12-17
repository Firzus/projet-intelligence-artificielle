using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] PlayerState _state;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(_state.CanMove)
        {
            OnMove(_state._speed);
        }
    }

    public void OnMove(float speed)
    {
        _rb.velocity = new Vector2(_horizontal * speed, _vertical * speed);
    }
}
