using System.Collections.Generic;
using UnityEngine;

public class WeaponManageur : MonoBehaviour
{
    [System.Serializable] public struct Weapon
    {
        public Sprite sp;
        [SerializeField] string type;
        public AudioClip audio;
        public Weapon addW(Sprite sprite, string wType, AudioClip wAudio)
        {
            sp = sprite;
            type = wType;
            audio = wAudio;
            return this;
        }
    }

    [SerializeField] List<Weapon> _weaponList;
    public List<Weapon> List {  get => _weaponList; }
    void Start()
    {
        
    }

    public Weapon ChooseWeapon()
    {
        int a = Random.Range(0, _weaponList.Count);
        Weapon w = _weaponList[a];
        return w;
    }
    private void addWeaponList(Sprite sp, string type, AudioClip audio)
    {
        Weapon w = new Weapon().addW(sp, type, audio);
        _weaponList.Add(w);
    }
}
