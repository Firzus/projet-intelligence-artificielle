using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : ActionNode
{
    [HideInInspector] private GameObject _target;
    [SerializeField] private float _fovRange;
    [SerializeField] private Sprite _actualSprite;
    [SerializeField] private string _actualType;
    [SerializeField] private AudioClip _actualAudio;
    private Sprite _wepSP;
    private int _index;
    private WeaponInventory _bossInv;
    private WeaponInventory.Weapon _weaponInv;


    protected override void OnStart()
    {
        _fovRange = agent.FovRange;
        _target = GameObject.FindWithTag("Player");
        _bossInv = agent.GetComponent<WeaponInventory>();
        _actualSprite = _bossInv._list[_index].sp;
        _actualType = _bossInv._list[_index].Type;
        _actualAudio = _bossInv._list[_index].audio;
        _weaponInv = _bossInv.ActualWeapon = _bossInv._list[_index];
        _wepSP = _bossInv._EntitieWeapon.GetComponent<SpriteRenderer>().sprite = _actualSprite;
    }
    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(agent.transform.position, _target.transform.position);

        if (dist > _fovRange) // Minigun
        {
            _index = 1;

            _actualSprite = _bossInv._list[_index].sp;
            _actualType = _bossInv._list[_index].Type;
            _actualAudio = _bossInv._list[_index].audio;

            _weaponInv.sp = _actualSprite;
            _weaponInv.Type = _actualType;
            _weaponInv.audio = _actualAudio;

            _bossInv._EntitieWeapon.GetComponent<SpriteRenderer>().sprite = _bossInv.ActualWeapon.sp;

            Debug.Log(_bossInv._list[_index].Type);

            return State.Success;
        }
        else // Shotgun
        {
            _index = 0;

            _actualSprite = _bossInv._list[_index].sp;
            _actualType = _bossInv._list[_index].Type;
            _actualAudio = _bossInv._list[_index].audio;

            _weaponInv.sp = _actualSprite;
            _weaponInv.Type = _actualType;
            _weaponInv.audio = _actualAudio;

            _bossInv._EntitieWeapon.GetComponent<SpriteRenderer>().sprite = _bossInv.ActualWeapon.sp;

            Debug.Log(_bossInv._list[_index].Type);

            return State.Failure;
        }
    }
}