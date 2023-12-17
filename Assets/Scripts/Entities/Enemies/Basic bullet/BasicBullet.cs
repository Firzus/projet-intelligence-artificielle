using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicBullet : Enemy
{
    public static float fovRange = 6f;

    void Start()
    {
        EnemyStart();
        SetValue(5, 5f);
    }

    void Update() 
    {

    }

    void Death()
    {
        Destroy();
    }
}