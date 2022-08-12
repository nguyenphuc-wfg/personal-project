using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStorage", menuName = "Tanks/WeaponStorage", order = 0)]
public class WeaponStorage : ScriptableObject {
    public SOGunWeapon gun01;
    public string bulletName;
    public GunWeapon gun02;
}