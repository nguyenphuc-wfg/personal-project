using UnityEngine;

[CreateAssetMenu(fileName = "DataGunWeapon", menuName = "Tanks/GunData/DataGunWeapon", order = 0)]
public class DataGunWeapon : DataWeapon {
    public int _bulletsPerRound = 1;
    public string _bulletName = "Bullet";
}