using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeaponControl : MonoBehaviour
{
    [SerializeField] private Transform _fireTransform;
    [SerializeField] private WeaponStorage _weaponStorage;
    [SerializeField] private WeaponManager _weaponManager;
    public int m_PlayerNumber = 1;
    private GunWeapon _weapon;
    private bool isDisable;
    public GameEvent changeWeaponEvent;
    [SerializeField] private TankStatus _tankStatus;
    [SerializeField] private TankEvent _tankEvent;
    private void OnEnable()
    {
        _tankEvent.SubscribeListener(TankStatusEvent);
        changeWeaponEvent.SubscribeListener(ChangeWeapon);
    }
    private void Start()
    {
        ChangeWeapon();
    }
    private void OnDisable()
    {
        _tankEvent.UnSubscribeListener(TankStatusEvent);
        changeWeaponEvent.UnSubscribeListener(ChangeWeapon);
    }
    private void Update()
    {
        if (isDisable) return;
        _weapon.OnUpdate();
    }
    public void ResetWeapon()
    {
        if (_weapon)
            _weapon.ResetWeapon();
    }
    public void ChangeWeapon()
    {
        _weapon = _weaponManager._weaponStorage[m_PlayerNumber - 1].gun;
        _weapon.SetUpData(_weaponManager._weaponStorage[m_PlayerNumber - 1].dataGun);
        _weapon._fireTransform = _fireTransform;
        _weapon._owner = this.gameObject;
        _weapon._bulletName = _weaponManager._weaponStorage[m_PlayerNumber - 1].bulletName;
        _weapon._idPlayer = m_PlayerNumber;
    }
    public void TankStatusEvent(TankStatusFlag flag)
    {
        isDisable = flag.HasFlag(TankStatusFlag.STUN) || flag.HasFlag(TankStatusFlag.SLEEP);
        if (isDisable) ResetWeapon();
    }
}
