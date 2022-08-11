using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
    public UnityEvent changeWeaponEvent;
    [SerializeField] private WeaponStorage _weaponStorage;
    [SerializeField] private List<SOGunWeapon> _listWeapon = new List<SOGunWeapon>();
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)){
            _weaponStorage.gun01 = _listWeapon[0];
            changeWeaponEvent.Invoke();
        } else
        if (Input.GetKeyDown(KeyCode.X)){
            _weaponStorage.gun01 = _listWeapon[1];
            changeWeaponEvent.Invoke();
        } else
        if (Input.GetKeyDown(KeyCode.C)){
            _weaponStorage.gun01 = _listWeapon[2];
            changeWeaponEvent.Invoke();
        }
    }    
}