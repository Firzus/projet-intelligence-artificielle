using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public bool _canMove;
    public int _speed = 1;
    void Start()
    {
        _canMove = true;
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

        Vector2 pos = transform.position;
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("teste Z");
            transform.position.Set(pos.x, pos.y + speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position.Set(pos.x, pos.y - speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position.Set(pos.x - speed, pos.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position.Set(pos.x + speed, pos.y, 0);
        }
    }
}
