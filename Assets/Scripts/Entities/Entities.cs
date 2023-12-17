using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    [HideInInspector] public int _hp;
    [HideInInspector] public float _speed;

    public abstract void Destroy();
    
}
