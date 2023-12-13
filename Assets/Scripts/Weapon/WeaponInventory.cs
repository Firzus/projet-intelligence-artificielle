using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class WeaponInventory : MonoBehaviour
{

    [System.Serializable] public struct Weapon
    {
        public Sprite sp;
        [SerializeField] string type;
        public string Type { get => type; set => type = value; }
    }

    public List<Weapon> _list;// = new List<Weapon>();
    public GameObject _playerWeapon;

    private Weapon _actualWeapon;
    public Weapon ActualWeapon { get => _actualWeapon; set => _actualWeapon = value; }
    private Sprite _actualSprite;
    private string _actualType;
    private int _index;

    void Start()
    {
        _index = 1;
        _actualSprite = _list[_index].sp;
        _actualType = _list[_index].Type;
        _actualWeapon = _list[_index];
        _playerWeapon.GetComponent<SpriteRenderer>().sprite = _actualSprite;
    }

    void Update()
    {
        if (ChangeWeapon())
        {
            UpdateWeapon();
        }
    }

    private bool ChangeWeapon()
    {
        //Debug.Log(_index + "   " + _list[_index].type);
        if(_list[_index].sp == null)
        {
            Debug.Log("teste");
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if(_index == _list.Count - 1)
            {
                _index = 0;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
            }
            else
            {
                _index += 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
            }

            return true;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (_index == 0)
            {
                _index = _list.Count - 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
            }
            else
            {
                _index -= 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
            }
            return true;
        }
        return false;
    }

    private void UpdateWeapon()
    {
        _actualWeapon.sp = _actualSprite;
        _actualWeapon.Type = _actualType;
        _playerWeapon.GetComponent<SpriteRenderer>().sprite = _actualWeapon.sp;
    }

}
