using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankWeapon : MonoBehaviour {
    [SerializeField] private Transform _fireTransform;
    [SerializeField] private WeaponStorage _weaponStorage;
    public int m_PlayerNumber = 1; 
    private SOGunWeapon _weapon;

    public GameEvent changeWeaponEvent;
    private void OnEnable() {
        ChangeWeapon();
        changeWeaponEvent.SubscribeListener(ChangeWeapon);
    }

    private void OnDisable() {
        changeWeaponEvent.UnSubscribeListener(ChangeWeapon);
    }
    private void Update() {
        _weapon.OnUpdate();
    }
    public void ResetWeapon(){
        // _weapon.ResetWeapon();
    }
    public void ChangeWeapon(){
        // _weapon = _weaponStorage.gun;
        // _weapon._fireTransform = _fireTransform;
        // _weapon._owner = this.gameObject;
        // _weapon._bulletName = _weaponStorage.bulletName;
    }
}