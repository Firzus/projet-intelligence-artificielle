using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicBullet : EntityState
{
    new public float FovRange;

    void Start()
    {
        FovRange = 6f;
        EnemyStart(5, 1.5f);
    }

    void Update() 
    {

    }

    void Death()
    {
       
    }
}