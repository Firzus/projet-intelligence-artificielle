using UnityEngine;
public class CreateWeapon : MonoBehaviour
{
    private  GameObject _weaponManager;
    private WeaponManageur.Weapon actualWeapon;
#if UNITY_EDITOR
    public void SetWeapon(EnemyStateManager enemy)
    {
        //Debug
        Debug.Log("Starting instantiate");
        //set path for local prefab
        string weaponPath = "Assets/Prefabs/Weapons/weapon.prefab";
        GameObject weapon = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(weaponPath);
        //Instantiate game object
        GameObject spawn = Instantiate(weapon);
        spawn.transform.SetParent(enemy.transform);
        //call function to set other script in the prefab
        SetTarget(spawn);
        //set settings for game object
        spawn.transform.position = enemy.transform.position;
        spawn.GetComponent<SpriteRenderer>().sprite = actualWeapon.sp;
        spawn.GetComponent<AudioSource>().clip = actualWeapon.audio;
        spawn.name = actualWeapon.Type;
        //Debug
        Debug.Log("weapon created");
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

    // private void SetInventory(GameObject gameObject){

    // }
}
