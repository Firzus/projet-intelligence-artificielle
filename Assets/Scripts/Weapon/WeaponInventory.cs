using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class WeaponInventory : MonoBehaviour
{

    [System.Serializable] public struct Weapon
    {
        public Sprite sp;
        [SerializeField] string type;
        public AudioClip audio;
        public string Type { get => type; set => type = value; }
    }

    public List<Weapon> _list;// = new List<Weapon>();
    public GameObject _EntitieWeapon;

    private Weapon _actualWeapon;
    public Weapon ActualWeapon { get => _actualWeapon; set => _actualWeapon = value; }
    private Sprite _actualSprite;
    private string _actualType;
    private AudioClip _actualAudio;
    private int _index;

    void Start()
    {
        _index = 0;
        _actualSprite = _list[_index].sp;
        _actualType = _list[_index].Type;
        _actualAudio = _list[_index].audio;
        _actualWeapon = _list[_index];
        _EntitieWeapon.GetComponent<SpriteRenderer>().sprite = _actualSprite;
        UpdateWeapon();
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
        if(_list[_index].sp == null)
        {
            Debug.Log("Weapon List null");
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if(_index == _list.Count - 1)
            {
                _index = 0;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
                _actualAudio = _list[_index].audio;
            }
            else
            {
                _index += 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
                _actualAudio = _list[_index].audio;
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
                _actualAudio = _list[_index].audio;
            }
            else
            {
                _index -= 1;
                _actualSprite = _list[_index].sp;
                _actualType = _list[_index].Type;
                _actualAudio = _list[_index].audio;
            }
            return true;
        }
        return false;
    }

    private void UpdateWeapon()
    {
        _actualWeapon.sp = _actualSprite;
        _actualWeapon.Type = _actualType;
        _actualWeapon.audio = _actualAudio;
        _EntitieWeapon.GetComponent<SpriteRenderer>().sprite = _actualWeapon.sp;
    }

}
