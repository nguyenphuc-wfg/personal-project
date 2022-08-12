using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStorage", menuName = "Tanks/WeaponStorage", order = 0)]
public class WeaponStorage : ScriptableObject {
    public string bulletName;
    public GunWeapon gun;
    public DataWeapon dataGun;
}