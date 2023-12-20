using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicBullet : EntityState
{
    new public float fovRange;

    void Start()
    {
        fovRange = 6f;
        EnemyStart(5, 1.5f);
    }

    void Update() 
    {

    }

    void Death()
    {
       
    }
}