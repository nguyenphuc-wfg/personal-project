using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {
    public UnityEvent changeWeaponEvent;
    public List<WeaponStorage> _weaponStorage = new List<WeaponStorage>();
    [SerializeField] private List<SOGunWeapon> _listWeapon = new List<SOGunWeapon>();
    [SerializeField] private List<string> _bulletName = new List<string>();
    [SerializeField] private List<GunWeapon> _listWeapon1 = new List<GunWeapon>();
    [SerializeField] private TankWeapon2 _tankWeapon2;

    private int _iBullet = 0;
    private int _iWeapon = 0;
    private void Start() {
        ChangeWeapon();
        ChangeBullet();
    }
    private void Update() {
        // Change Weapon
        if (Input.GetButtonDown($"ChangeWp{_tankWeapon2.m_PlayerNumber}")){
            ChangeWeapon();
        }

        // Change Bullet
        if (Input.GetButtonDown($"ChangeBullet{_tankWeapon2.m_PlayerNumber}")){
            ChangeBullet();
        }
    }    
    private void ChangeWeapon(){
        _iWeapon = ++_iWeapon >= _listWeapon.Count ? 0 : _iWeapon++;
        // _weaponStorage[_tankWeapon2.m_PlayerNumber-1].gun01 = _listWeapon[_iWeapon];
        _weaponStorage[_tankWeapon2.m_PlayerNumber-1].gun02 = _listWeapon1[_iWeapon];
        changeWeaponEvent.Invoke();
    }
    private void ChangeBullet(){
        _iBullet = ++_iBullet >= _listWeapon.Count ? 0 : _iBullet++;
        _weaponStorage[_tankWeapon2.m_PlayerNumber-1].bulletName = _bulletName[_iBullet];
        changeWeaponEvent.Invoke();
    }
}