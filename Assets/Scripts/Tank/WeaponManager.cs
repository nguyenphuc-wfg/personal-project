using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
    public UnityEvent changeWeaponEvent;
    [SerializeField] private WeaponStorage _weaponStorage;
    [SerializeField] private List<SOGunWeapon> _listWeapon = new List<SOGunWeapon>();
    [SerializeField] private List<string> _bulletName = new List<string>();
    private void Update() {
        // Change Weapon
        if (Input.GetKeyDown(KeyCode.Z)){
            ChangeWeapon(0);
        } else
        if (Input.GetKeyDown(KeyCode.X)){
            ChangeWeapon(1);
        } else
        if (Input.GetKeyDown(KeyCode.C)){
            ChangeWeapon(2);
        }

        // Change Bullet
        if (Input.GetKeyDown(KeyCode.V)){
            ChangeBullet(0);            
        } else 
        if (Input.GetKeyDown(KeyCode.B)){
            ChangeBullet(1);            
        } else 
        if (Input.GetKeyDown(KeyCode.N)){
            ChangeBullet(2);            
        } else
        if (Input.GetKeyDown(KeyCode.M)){
            ChangeBullet(3);            
        }
    }    
    private void ChangeWeapon(int i){
        _weaponStorage.gun01 = _listWeapon[i];
        changeWeaponEvent.Invoke();
    }
    private void ChangeBullet(int i){
        _weaponStorage.bulletName = _bulletName[i];
        changeWeaponEvent.Invoke();
    }
}