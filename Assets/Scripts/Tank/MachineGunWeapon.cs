using UnityEngine;

public class MachineGunWeapon: GunWeapon{
    private float _currentFiredInterval = 0;
    [SerializeField] private float _fireBulletInterval = 1;
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
}