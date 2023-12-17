using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeteranBullet : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        EnemyStart();
        SetValue(50, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        Destroy();
    }
}
