using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : ActionNode
{
    [HideInInspector] private GameObject _target;
    [SerializeField] private float fovRange;
    [SerializeField] private Sprite _actualSprite;
    [SerializeField] private string _actualType;
    [SerializeField] private AudioClip _actualAudio;
    [SerializeField] private int _index;
    [SerializeField] private WeaponInventory _bossInv;


    protected override void OnStart()
    {
        fovRange = agent.fovRange;
        _target = GameObject.FindWithTag("Player");
        _bossInv = agent.GetComponent<WeaponInventory>();
        _index = _bossInv.Index;
        _actualSprite = _bossInv._list[_index].sp;
        _actualType = _bossInv._list[_index].Type;
        _actualAudio = _bossInv._list[_index].audio;
        _bossInv.ActualWeapon = _bossInv._list[_index];
        _bossInv._EntitieWeapon.GetComponent<SpriteRenderer>().sprite = _actualSprite;
        _bossInv.UpdateWeapon();
    }
    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        float dist = Vector2.Distance(agent.transform.position, _target.transform.position);

        if (dist >= fovRange)
        {
            _index = 1;
            _actualSprite = _bossInv._list[_index].sp;
            _actualType = _bossInv._list[_index].Type;
            _actualAudio = _bossInv._list[_index].audio;
            _bossInv.UpdateWeapon();
            return State.Success;
        }
        else if (dist <= fovRange)
        {
            _index = 0;
            _actualSprite = _bossInv._list[_index].sp;
            _actualType = _bossInv._list[_index].Type;
            _actualAudio = _bossInv._list[_index].audio;
            return State.Failure;
        }
        return State.Running;
        
    }
}
