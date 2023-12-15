using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    GameObject _weaponManager;
    GameObject weapon;
    private WeaponManageur.Weapon actualWeapon;
    // Start is called before the first frame update
    void Start()
    {
        string weaponPath = "Assets/Prefabs/Weapons/weapon.prefab";
        weapon = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(weaponPath);
        _weaponManager = GameObject.Find("WeaponManager");
        actualWeapon = _weaponManager.GetComponent<WeaponManageur>().ChooseWeapon();
    }

    public void SetWeapon(EnemyStateManager enemy)
    {
        GameObject spawn = Instantiate(weapon, enemy.transform.position, enemy.transform.rotation, enemy.transform);
        spawn.GetComponent<SpriteRenderer>().sprite = actualWeapon.sp;
        spawn.GetComponent<AudioSource>().clip = actualWeapon.audio;
        spawn.name = actualWeapon.Type;
    }
}
