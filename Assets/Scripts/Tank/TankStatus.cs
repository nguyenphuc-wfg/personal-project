using UnityEngine;
using System;

public class TankStatus : MonoBehaviour {
    [SerializeField] private TankComponent _tankComponent;
    public TankComponent TankComponent {get{return _tankComponent;}}
    
    public bool isRoot;
    public bool isStun;
    public bool isTimeStop;
    public bool isSleep;
    
    public void OnStun(){
        isStun = true;
        _tankComponent.TankWeaponControl.enabled = false;
        // _tankComponent.TankMovement.enabled = false;
        _tankComponent.WeaponManager.enabled = false;
        _tankComponent.TankWeaponControl.ResetWeapon();
    }
    public void OffStun(){
        isStun = false;
        // _tankComponent.TankMovement.enabled = true;
        if (isSleep) return;
        _tankComponent.TankWeaponControl.enabled = true;
        _tankComponent.WeaponManager.enabled = true;
    }
    public void OnRoot(){
        isRoot = true;
        // _tankComponent.TankMovement.enabled = false;
    }
    public void OffRoot(){
        isRoot = false;
        // _tankComponent.TankMovement.enabled = true;
    }
    public void OnSleep(){
        isSleep = true;
        _tankComponent.TankWeaponControl.enabled = false;
        // _tankComponent.TankMovement.enabled = false;
        _tankComponent.WeaponManager.enabled = false;
        _tankComponent.TankWeaponControl.ResetWeapon();
    }
    public void OffSleep(){
        isSleep = false;
        if (isStun) return;
        // _tankComponent.TankMovement.enabled = true;
        _tankComponent.TankWeaponControl.enabled = true;
        _tankComponent.WeaponManager.enabled = true;
    }
}