using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyStart();
        SetValue(10, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
