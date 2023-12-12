using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class WeaponInventory : MonoBehaviour
{

    [System.Serializable] public struct Weapon
    {
        public Sprite sp;
        public string type;
    }

    [SerializeField] public List<Weapon> _list;// = new List<Weapon>();
    [HideInInspector] private Weapon _actualWeapon;
    public GameObject _playerWeapon;
    private Sprite _actualSprite;
    private string _actualType;
    private int _index;

    void Start()
    {
        _index = 1;
        _actualSprite = _list[_index].sp;
        _actualType = _list[_index].type;
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
                _actualType = _list[_index].type;
            }
            else
            {
                _index += 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].type;
            }

            return true;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (_index == 0)
            {
                _index = _list.Count - 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].type;
            }
            else
            {
                _index -= 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].type;
            }
            return true;
        }
        return false;
    }

    private void UpdateWeapon()
    {
        _actualWeapon.sp = _actualSprite;
        _actualWeapon.type = _actualType;
        _playerWeapon.GetComponent<SpriteRenderer>().sprite = _actualWeapon.sp;
    }

}
