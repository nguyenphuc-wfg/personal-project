using UnityEngine;

public class MachineGunWeapon: GunWeapon{
    private float _currentFiredInterval = 0;
    private float _fireBulletInterval = 1;
    protected override void UpdateFiring()
    {
        _currentFiredInterval -= Time.deltaTime;
        if (_currentFiredInterval <= 0) {
            FireOneBullet();
            _currentFiredInterval = _fireBulletInterval;
        }
    }
    protected override void OnFinishFireRound()
    {
        base.OnFinishFireRound();
        _currentFiredInterval = 0f;
    }

    public override void ResetWeapon()
    {
        base.ResetWeapon();
        _currentFiredInterval = 0f;
    }
    public override void SetUpData(DataWeapon data){
        base.SetUpData(data);
        if (!(data is DataMachineGun dataMachineGun)) 
            return;
        _fireBulletInterval = dataMachineGun._fireBulletInterval;
    }
}