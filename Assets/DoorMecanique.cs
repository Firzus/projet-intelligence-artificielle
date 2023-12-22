using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMecanique : MonoBehaviour
{
    [SerializeField] int _killRequest;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] EntityState _playerState;
    [SerializeField] GameObject _openedDoor;

    private bool _isOpen;
    public bool IsOpen {  get { return _isOpen; } set { _isOpen = value; } }

    void Start()
    {
        _collider.enabled = true;
        _isOpen = false;
        if ( _playerState == null )
        {
            _playerState = GameObject.FindWithTag("Player").GetComponent<EntityState>();
        }
    }


    void Update()
    {
        if (_playerState.KillCount >= _killRequest) 
        {
            _isOpen = true;
            Instantiate(_openedDoor, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
