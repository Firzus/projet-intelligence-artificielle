using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entities
{
    public bool isInRange;
    public bool playerIn;
    public bool playerOut;

    public override void Destroy()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
