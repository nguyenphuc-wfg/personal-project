using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon2 : MonoBehaviour
{
    [SerializeField] private Transform _fireTransform;
    [SerializeField] private WeaponStorage _weaponStorage;
    [SerializeField] private WeaponManager _weaponManager;
    public int m_PlayerNumber = 1; 
    private GunWeapon _weapon;

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
        _weapon.ResetWeapon();
    }
    public void ChangeWeapon(){
        _weapon = _weaponManager._weaponStorage[m_PlayerNumber-1].gun02;
        _weapon._fireTransform = _fireTransform;
        _weapon._owner = this.gameObject;
        _weapon._bulletName = _weaponManager._weaponStorage[m_PlayerNumber-1].bulletName;
        _weapon._idPlayer = m_PlayerNumber;
    }
}
