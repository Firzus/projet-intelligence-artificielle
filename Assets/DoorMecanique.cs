using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMecanique : MonoBehaviour
{
    [SerializeField] int _killRequest;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] EntityState _playerState;
    void Start()
    {
        _collider.enabled = true;
    }


    void Update()
    {
        
    }
}
