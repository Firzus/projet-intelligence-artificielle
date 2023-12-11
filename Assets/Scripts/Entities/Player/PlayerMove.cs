using UnityEngine;

public class PlayerMove : PlayerState
{

    void Start()
    {
        
    }


    void Update()
    {
        if(_canMove == true)
        {
            OnMove(_speed);
        }
    }

    public void OnMove(float speed)
    {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }

    }
}
