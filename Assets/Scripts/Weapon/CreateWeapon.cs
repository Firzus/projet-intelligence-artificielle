using UnityEngine;
using UnityEditor;
public class CreateWeapon : MonoBehaviour
{
    private  GameObject _weaponManager;
    private WeaponManageur.Weapon actualWeapon;
#if UNITY_EDITOR
    public void SetWeapon(EnemyStateManager enemy)
    {
        //Debug
        //set path for local prefab
        string weaponPath = "Assets/Prefabs/Weapons/weapon.prefab";
        GameObject weapon = AssetDatabase.LoadAssetAtPath<GameObject>(weaponPath);
        //Instantiate game object
        GameObject spawn = Instantiate(weapon);
        spawn.transform.SetParent(enemy.transform);
        //call function to set other script in the prefab
        SetTarget(spawn);
        SetInventory(enemy, spawn);
        //set settings for game object
        spawn.transform.position = enemy.transform.position;
        spawn.GetComponent<SpriteRenderer>().sprite = actualWeapon.sp;
        spawn.GetComponent<AudioSource>().clip = actualWeapon.audio;
        spawn.name = actualWeapon.Type;
        //Debug
    }
#endif
    private void SetTarget(GameObject gameObject){
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        gameObject.GetComponent<WeaponAim>()._target = target;
    }

    public void Init(){
        _weaponManager = GameObject.Find("WeaponManager");
        actualWeapon = _weaponManager.GetComponent<WeaponManageur>().ChooseWeapon();
    }

    private void SetInventory(EnemyStateManager enemy, GameObject gameObject){
        enemy.GetComponent<WeaponInventory>().AddWeapon(actualWeapon.sp, actualWeapon.Type, actualWeapon.audio);
        enemy.GetComponent<WeaponInventory>()._EntitieWeapon = gameObject;
    }
}
