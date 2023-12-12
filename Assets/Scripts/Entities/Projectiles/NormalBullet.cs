using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    void Start()
    {
        int dmg = 5;
        int speed = 5;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {

            Destroy(gameObject);
        }
    }
}
