using UnityEngine;
public class CreateWeapon : MonoBehaviour
{
    GameObject _weaponManager;
    private WeaponManageur.Weapon actualWeapon;
    // Start is called before the first frame update
    void Start()
    {
        _weaponManager = GameObject.Find("WeaponManager");
        actualWeapon = _weaponManager.GetComponent<WeaponManageur>().ChooseWeapon();
    }

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

    private void SetTarget(GameObject gameObject){
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<WeaponAim>()._target = target;
    }

    private void SetInventory(GameObject gameObject){

    }
}
