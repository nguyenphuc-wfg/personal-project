using UnityEngine;

public class RadiateGunWeapon: GunWeapon {
    private float _radiateAngle;
    protected override void UpdateFiring()
    {
        int startIndex = _bulletsPerRound % 2 == 0 ? 2 : 1;
        int endIndex = _bulletsPerRound % 2 == 0 ? _bulletsPerRound + 1 : _bulletsPerRound;
        for (int i = startIndex; i <= endIndex; i++ ){
            var pos = _fireTransform.position;
            var euler = _fireTransform.eulerAngles;
        
            if (_bulletsPerRound % 2 != 0)
                euler.y += _radiateAngle * (i % 2 == 0 ? -i/2 : i/2);
            else {
                if (i == 1 || i == 2) {
                    euler.y += i == 1 ? _radiateAngle/2 : -_radiateAngle/2;
                } else {
                    euler.y += (i % 2 == 0 ? _radiateAngle/2 : -_radiateAngle/2) + _radiateAngle * (i % 2 == 0 ? -i/2 : i/2);
                }
            }
            var rotation =  Quaternion.Euler(euler);
            FireOneBullet(pos, rotation);
        }
    }
    public override void SetUpData(DataWeapon data){
        base.SetUpData(data);
        if (!(data is DataRadiateGun dataRadiateGun)) 
            return;
        _radiateAngle = dataRadiateGun._radiateAngle;
    }
}