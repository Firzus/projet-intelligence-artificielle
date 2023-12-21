using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMecanique : MonoBehaviour
{
    [SerializeField] int _killRequest;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] EntityState _playerState;
    [SerializeField] GameObject _openedDoor;

    [SerializeField] int _roomNumbers;
    public int RoomNumbers {  get { return _roomNumbers; } set {  _roomNumbers = value; } }

    void Start()
    {
        _collider.enabled = true;
        if ( _playerState == null )
        {
            _playerState = GameObject.FindWithTag("Player").GetComponent<EntityState>();
        }
    }


    void Update()
    {
        if (_playerState.KillCount >= _killRequest) 
        {
            Instantiate(_openedDoor, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
