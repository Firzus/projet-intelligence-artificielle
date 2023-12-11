using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    public int hp;
    public float speed;

    public abstract void Destroy();
    
}
